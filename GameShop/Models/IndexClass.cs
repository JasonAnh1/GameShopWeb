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

        public product detailProduct { get; set; }
        public List<product_img_url> lstImg { get; set; }
    }
}