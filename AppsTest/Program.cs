using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arabia.Core.Data;
using Arabia.Core.Domain.News;
using Arabia.Core.Data;
using Arabia.Data;
using MongoDB.Bson;

namespace AppsTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IMongoRepository<NewsItem> newsItemService = new MongoDbRepository<NewsItem>();
            //for (int i = 2; i <= 10; i++)
            //{
            //    var newsItem = new NewsItem()
            //    {
            //        Body = "testBody" + i,
            //        DocumentId = 5000000 + i,
            //        ImageId = 5 + i,
            //        Summary = "testSummery" + i,
            //        PublishDate = DateTime.Now,
            //        Title = "testTitle" + i,
            //        ViewCount = i
            //    };
            //    newsItemService.Insert(newsItem);
            //}

            //Console.WriteLine("done");
            //Console.Read();

            //var item = newsItemService.GetById(new ObjectId("55462cf692dc6f02ec86d51a"));
            //Console.WriteLine(item.Id);
            //Console.WriteLine(item.DocumentId);

            //item.DocumentId = 55;
            //newsItemService.Delete(item.Id);

            //var item2 = newsItemService.GetById(item.Id);

            //Console.WriteLine(item2.Id);
            //Console.WriteLine(item2.DocumentId);

            var newsItem = new NewsItem()
               {
                   Body = "testBody",
                   DocumentId = 8888,
                   ImageId = 5,
                   Summary = "testSummery",
                   PublishDate = DateTime.Now,
                   Title = "testTitle",
                   ViewCount = 0
               };
            newsItemService.Add(newsItem);
            Console.WriteLine(newsItem.Id);
            Console.Read();
        }
    }
}
