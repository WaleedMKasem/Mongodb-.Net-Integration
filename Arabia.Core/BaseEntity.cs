using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Arabia.Core
{
    public abstract partial class BaseEntity
    {
        protected BaseEntity()
        { 
        }
        [BsonElement(Order = 1)]
        public ObjectId Id { get; set; }
    }
}
