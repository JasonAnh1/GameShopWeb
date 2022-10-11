using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class CheckOutController : Controller
    {
        game_shop_webEntities db = new game_shop_webEntities();
        // GET: CheckOut
        // tinh tien va xoa
        public ActionResult Cart()
        {
            cartReturn cartR = new cartReturn();
            List<product> list = new List<product>();
            if (Session["listCart"] != null)
            {
                list = (List<product>)Session["listCart"]; 
            }
            // viet tiep loop qua list san pham de tinh tien
            cartR.list = list;
            cartR.total = 0;
            foreach(var item in list)
            {
                cartR.total += item.price;
            }
             return View(cartR);
        }
        public ActionResult AddToCart(int productId)
        {
            if (Session["listCart"] == null)
            {
                Session["listCart"] = new List<product>();
            }
            product pd = db.products.Where(n => n.id.Equals(productId)).SingleOrDefault();
            if (pd != null && pd.quantity > 0)
            {
                List<product> list = (List<product>)Session["listCart"];
                list.Add(pd);
                Session["listCart"] = list;
            }
            return RedirectToAction("Index","Index");
        }
        public ActionResult RemoveFromCart(int productId)
        {
            List<product> list = (List<product>)Session["listCart"];
            product pd = list.FirstOrDefault(u => u.id.Equals(productId));
            if (pd != null)
            {
                list.Remove(pd);
            }
            Session["listCart"] = list;
            return RedirectToAction("Cart", "CheckOut");
        }
        public ActionResult CheckOut()
        {
            if (Session["norUser"] == null)
            {
                return RedirectToAction("Index", "Login", new { area = "Admin" });
            }
            user user = (user)Session["norUser"];
            ViewBag.email = user.Email;
            ViewBag.username = user.name;
            ViewBag.userId = user.id;
            cartReturn cartR = new cartReturn();
            List<product> list = new List<product>();
            if (Session["listCart"] != null)
            {
                list = (List<product>)Session["listCart"];
            }
            // viet tiep loop qua list san pham de tinh tien
            cartR.list = list;
            cartR.total = 0;
            foreach (var item in list)
            {
                cartR.total += item.price;
            }
            return View(cartR);
        }
        [HttpPost]
        public ActionResult CheckOut2(string email,int userId )
        {
            order orderr = new order();
            orderr.email = email;
            orderr.users_id = userId;
            order orderFin =  db.orders.Add(orderr);
           List<product> list = new List<product>();
            if (Session["listCart"] != null)
            {
                list = (List<product>)Session["listCart"];
            }
            List<order_product> listord = new List<order_product>();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    order_product op = new order_product();          
                    op.update_at = DateTime.Now;
                    op.quantity = item.quantity;
                    op.product_id = item.id;
                    op.orders_id = orderFin.id;
                    listord.Add(op);
                }
            }
            db.order_product.AddRange(listord);
            db.SaveChanges();
            return RedirectToAction("index", "index");
        }
    }
}
