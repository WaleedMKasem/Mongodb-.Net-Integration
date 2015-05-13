using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arabia.Core.Domain.Albums;
using Arabia.Core.Domain.General;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Arabia.Core.Domain.Interviews
{
    public class Interview : BaseEntity
    {
        public Interview()
        {
        }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<Point> Points { get; set; }
        public List<Image> Images { get; set; }
        public Editor Editor { get; set; }
        public Interviewee Interviewee { get; set; }
        public List<RelatedNewsItem> RelatedNews { get; set; }
        public int Views { get; set; }
        public int Comments { get; set; }
        public int Tweets { get; set; }
        public int Shares { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
    }

    public class Point
    {
        public Point()
        {
        }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    public class Interviewee
    {
        public Interviewee()
        {
        }
        public string Name { get; set; }
        public int ImageId { get; set; }
    }
}
