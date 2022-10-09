using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class IndexController : Controller
    {
        game_shop_webEntities db = new game_shop_webEntities();
        // GET: Index
        public ActionResult Index()
        {   
            IndexClass banner = new IndexClass();
            banner.banner = db.banners.Take(1).OrderByDescending(n => n.create_at).SingleOrDefault();
            banner.bannerList = db.banners.Take(4).OrderByDescending(n => n.create_at).Skip(1).ToList();
            banner.productList = db.products.Take(8).OrderByDescending(n => n.create_at).ToList();
            banner.categoryList = db.categories.ToList();
            return View(banner);
        }
    }
}