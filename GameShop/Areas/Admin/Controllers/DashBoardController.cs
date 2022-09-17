using GameShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace GameShop.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: Admin/DashBoard
        game_shop_webEntities db = new game_shop_webEntities();
        public ActionResult Index()
        {
            List<GameShop.Models.user> listUser = db.users.ToList(); 
            return View(db.users.ToList());

        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            user user = new user();

            return View(user);
        }
        [HttpPost]
        public ActionResult CreateUser(user user)
        {
            try
            {
                if (user.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(user.ImageUpload.FileName);
                    string extenstion = Path.GetExtension(user.ImageUpload.FileName);
                    fileName = fileName + extenstion;
                    user.img_url = "~/Asset/admin/img/" + fileName;
                    user.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Asset/admin/img/"), fileName));
                }

                user.create_at = DateTime.Now;
                db.users.Add(user);
                db.SaveChanges();
                ModelState.Clear();

                return RedirectToAction("Index", "DashBoard");
            }
            catch
            {
                return View();
            }
        }
    }
}