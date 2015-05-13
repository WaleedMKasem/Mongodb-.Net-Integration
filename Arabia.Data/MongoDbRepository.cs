using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Configuration;
using System.Data.Entity.Design.PluralizationServices;
using Arabia.Core;
using Arabia.Core.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Arabia.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class MongoDbRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly MongoCollection _collection;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public MongoDbRepository(string connection = "MongoDB")
        {
            var db = Connect(connection);
            _collection = db.GetCollection<T>(ToCamelCase(typeof(T).Name));
        }

        #endregion

        #region Methods

        public T GetById(ObjectId id)
        {
            return _collection.FindOneByIdAs<T>(id);
        }

        public bool Add(T entity)
        {
            //return _collection.Insert(entity).DocumentsAffected > 0;
           return _collection.Save(entity).DocumentsAffected>0;
        }

        public bool Update(T entity)
        {
            var query = Query<T>.EQ(e => e.Id, entity.Id);
            var update = Update<T>.Replace(entity); // update modifiers
            return _collection.Update(query, update).DocumentsAffected > 0;
        }
        public bool Increment(Expression<Func<T, long>> field, ObjectId id)
        {
            var query = Query<T>.EQ(p => p.Id, id);
            var inc = Update<T>.Inc(field, 1);
           return _collection.Update(query, inc, UpdateFlags.Upsert).DocumentsAffected>0;
        }

        public bool Remove(ObjectId id)
        {
            var query = Query<T>.EQ(e => e.Id, id);
            return _collection.Remove(query).DocumentsAffected > 0;
        }

        public IList<T> GetBySpec(Expression<Func<T, bool>> predicate)
        {
            return _collection.AsQueryable<T>().Where(predicate.Compile()).ToList();
        }
        public IList<T> GetByQuery(IMongoQuery query)
        {
            return _collection.FindAs<T>(query).ToList();
        }

        #endregion

        #region Properties

        public IQueryable<T> Collection
        {
            get { return _collection.AsQueryable<T>(); }
        }

        #endregion

        #region Private Methods

        private MongoDatabase Connect(string connection)
        {
            var uri = ConfigurationManager.ConnectionStrings[connection.Trim()].ConnectionString;
            var client = new MongoClient(uri);
            var database = client.GetServer().GetDatabase(new MongoUrl(uri).DatabaseName);

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camel case", pack, t => true);

            return database;
        }

        // Convert the string to camel case.
        private string ToCamelCase(string str)
        {
            //str = ToPascalCase(str);
            var camel= str.Substring(0, 1).ToLower() + str.Substring(1);
           return PluralizationService.CreateService(new CultureInfo("en-US")).Pluralize(camel);
        }
        // Convert the string to Pascal case.
        private string ToPascalCase(string str)
        {
            TextInfo info = Thread.CurrentThread.CurrentCulture.TextInfo;
            str = info.ToTitleCase(str);
            string[] parts = str.Split(new char[] { },
                StringSplitOptions.RemoveEmptyEntries);
            string result = String.Join(String.Empty, parts);
            return result;
        }
        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        public string ToProperCase(string str)
        {
            const string pattern = @"(?<=\w)(?=[A-Z])";
            //const string pattern = @"(?<=[^A-Z])(?=[A-Z])";
            string result = Regex.Replace(str, pattern, " ", RegexOptions.None);
            return result.Substring(0, 1).ToUpper() + result.Substring(1);
        }

        #endregion


    }
}