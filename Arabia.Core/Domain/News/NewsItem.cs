using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Arabia.Core.Domain.News
{
   public class NewsItem:BaseEntity
   {
       public NewsItem()
       {
       }
       public int DocumentId { get; set; }
       public string Title { get; set; }
       public string Summary { get; set; }
       public string Body { get; set; }
       public string Keywords { get; set; }
       public int? ImageId { get; set; }
       [BsonIgnoreIfNull]
       public int? EditorId { get; set; }
       public string AuthorName { get; set; }
       [BsonIgnoreIfNull]
       public int? AuthorImageId { get; set; }
       public int? ViewCount { get; set; }
       public DateTime? PublishDate { get; set; }

       //public int DocumentId { get; set; }
       //public string Title { get; set; }
       //public string SubTitle { get; set; }
       //public string Summary { get; set; }
       //public string Body { get; set; }
       //public string BodyText { get; set; }
       //public string Keywords { get; set; }
       //public Nullable<byte> DocumentTypeID { get; set; }
       //public Nullable<int> ImageID { get; set; }
       //public string ImageComment { get; set; }
       //public Nullable<byte> StatusID { get; set; }
       //public Nullable<System.DateTime> EditDate { get; set; }
       //public Nullable<System.DateTime> PublishDate { get; set; }
       //public Nullable<byte> SiteID { get; set; }
       //public Nullable<int> RatingValue { get; set; }
       //public Nullable<int> RatingCount { get; set; }
       //public Nullable<int> ViewCount { get; set; }
       //public Nullable<int> PrintCount { get; set; }
       //public Nullable<int> SaveCount { get; set; }
       //public Nullable<int> SendCount { get; set; }
       //public Nullable<bool> CommentsAllowed { get; set; }
       //public Nullable<bool> ShowInTicker { get; set; }
       //public Nullable<System.Guid> DocumentGUID { get; set; }
       //public string TempDocumentBody { get; set; }
       //public Nullable<byte> Complete { get; set; }
       //public string AuthorName { get; set; }
       //public Nullable<int> AuthorImageID { get; set; }
       //public Nullable<int> EditorID { get; set; }
       //public string DocumentLocations { get; set; }
       //public string DocumentCountries { get; set; }
       //public string DocumentSubjects { get; set; }
       //public string DocumentNews { get; set; }
       //public string DocumentImages { get; set; }
       //public string DocumentCompetetions { get; set; }
       //public string DocumentTeams { get; set; }
       //public string DocumentPlayers { get; set; }
       //public string DocumentMatches { get; set; }
       //public string DocumentVideos { get; set; }
       //public string DocumentDescription { get; set; }
       //public string SiteIDs { get; set; }
       //public Nullable<bool> isInfographic { get; set; }
    }
}
