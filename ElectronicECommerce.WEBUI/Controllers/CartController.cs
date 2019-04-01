using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.WEBUI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicECommerce.WEBUI.Controllers
{
    public class CartController : Controller
    {
        Repository<Product> repoProduct = new Repository<Product>();
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["CKCart"] != null)
            {
                HttpCookie httpCookie = Request.Cookies["CKCart"];
                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(httpCookie.Value);
                List<CartDetail> cartDetails = new List<CartDetail>();
                foreach (Cart hbc in carts)
                {
                    cartDetails.Add(new CartDetail
                    {
                        ProductID = hbc.ProductID,
                        Quantity = hbc.Quantity,
                        FPath = repoProduct.GetAll().Where(w => w.ID == hbc.ProductID).FirstOrDefault().Pictures.FirstOrDefault(f => f.PIndex == 1).PCartPath,
                        Price = repoProduct.GetBy(g => g.ID == hbc.ProductID).Price,
                        ProductName = repoProduct.GetBy(g => g.ID == hbc.ProductID).Name
                    }
                    );
                }
                CartVM cartVM = new CartVM
                {
                    CartDetails = cartDetails,
                    BestSellerProducts = repoProduct.GetAll().OrderByDescending(o => o.OrderDetails.Sum(s => s.Quantity)).Take(8).ToList()
                };
                return View(cartVM);
            }
            else
            {
                return RedirectToAction("EmptyCart");
            }
        }
        public ActionResult EmptyCart()
        {
            return View();
        }
    }
}