using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class IndexClass
    {
        public List<banner> bannerList { get; set; }
        public banner banner { get; set; }
        public List<product> productList { get; set; }
        public List<category> categoryList { get; set; }

        public int numberOfProcduct { get; set; }
    }
}