using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabia.Core.Domain.Albums
{
    public class Image
    {
        public Image()
        {
        }
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
