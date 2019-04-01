using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.WEBUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicECommerce.WEBUI.Controllers
{
    public class AJAXController : Controller
    {
        Repository<District> repoDistrict = new Repository<District>();
        Repository<Member> repoMember = new Repository<Member>();
        Repository<Favorite> repoFavorite = new Repository<Favorite>();

        [HttpPost]
        public void AddCart(int productID, int quantity)
        {
            CartHelper.AddCart(productID, quantity);
        }
        [HttpPost]
        public void UpdateCart(int productID, int quantity)
        {
            CartHelper.UpdateCart(productID, quantity);
        }
        [HttpPost]
        public void DeleteCart(int productID)
        {
            CartHelper.DeleteCart(productID);
        }

        public ActionResult GetDistrict(int cityID)
        {
            return Json(repoDistrict.GetAll().Where(w => w.CityID == cityID).Select(s => new { s.ID, s.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int AddProductFavorite(int id)
        {
            if (Session["MemberID"] != null)
            {
                int memberID = Convert.ToInt32(Session["MemberID"].ToString());
                Member member = repoMember.GetBy(g => g.ID == memberID);
                Favorite favorite = repoFavorite.GetBy(g => g.MemberID == memberID && g.ProductID == id);
                if(favorite != null)
                {
                    repoFavorite.Remove(favorite);
                    return 0;
                }
                else
                {
                    repoFavorite.Add(new Favorite { MemberID = memberID, ProductID = id });
                    return 1;
                }
            }
            else
                return 0;
        }
    }
}