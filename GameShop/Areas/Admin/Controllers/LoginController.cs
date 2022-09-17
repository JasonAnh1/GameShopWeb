using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        game_shop_webEntities db = new game_shop_webEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(GameShop.Models.user userModel)
        {
            var userDetail = db.users.Where(x => x.name==userModel.name
            && x.password ==userModel.password)
                .FirstOrDefault();
            if (userDetail == null)
            {
                userModel.LoginErrorMessage = "Wrong username or password";
                return View("Index",userModel);
            }
            if(userDetail.permission != 1)
            {
                userModel.LoginErrorMessage = "You dont have permission";
                return View("Index", userModel);
            }
            else
            {
                Session["userName"] = userDetail.name;
                return RedirectToAction("Index", "DashBoard");
            }
        }
    }
}