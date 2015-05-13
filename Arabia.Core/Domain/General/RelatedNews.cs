using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Arabia.Core.Domain.General
{
    public class RelatedNewsItem
    {
        public RelatedNewsItem()
        {
        }
        public string Title { get; set; }
        public int ImageId { get; set; }
        [BsonIgnoreIfNull]
        public DateTime? PublishedOn { get; set; }
        [BsonIgnoreIfNull]
        public int? Views { get; set; }
        [BsonIgnoreIfNull]
        public int? Comments { get; set; }
    }
}
