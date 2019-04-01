using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.WebUI.ViewModels;
using ElectronicECommerce.WEBUI.Helper;
using ElectronicECommerce.WEBUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicECommerce.WEBUI.Controllers
{

    public class HomeController : Controller
    {
        Repository<Slider> repoSlider = new Repository<Slider>();
        Repository<Product> repoProduct = new Repository<Product>();
        Repository<Picture> repoPicture = new Repository<Picture>();
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<Brand> repoBrand = new Repository<Brand>();
        Repository<QuestionCategory> repoQuestionCategory = new Repository<QuestionCategory>();
        Repository<Advertisement> repoAdvertisement = new Repository<Advertisement>();
        public ActionResult Index()
        {
            ViewBag.MenuIndex = 1;

            IndexVM indexVM = new IndexVM
            {
                pictures = repoPicture.GetAll().Where(w => w.PIndex == 1).ToList(),
                NewestProducts = repoProduct.GetAll().OrderByDescending(o => o.ID).Take(8).ToList(),
                BestSellerProducts = repoProduct.GetAll().OrderByDescending(o => o.OrderDetails.Sum(s => s.Quantity)).Take(8).ToList(),
                advertisements = repoAdvertisement.GetAll().OrderBy(o=>o.PIndex).Take(2).ToList()
            };
            return View(indexVM);
        }

        public ActionResult Contact()
        {
            ViewBag.MenuIndex = 5;
            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.MenuIndex = 3;
            return View();
        }

        public ActionResult SSS()
        {
            ViewBag.MenuIndex = 4;
            
            return View(repoQuestionCategory.GetAll().ToList());
        }

        public ActionResult Categories() // PartialView
        {
            return PartialView(repoCategory.GetAll().Where(w => w.ParentID == null).ToList());
        }
        public ActionResult Footer() // PartialView
        {
            ViewBag.MenuIndex = 2;
            FooterVM footerVM = new FooterVM {
                categories = repoCategory.GetAll().Where(w => w.ParentID == null).Take(4).ToList(),
                brands = repoBrand.GetAll().Take(4).ToList(),
                questionCategories = repoQuestionCategory.GetAll().Take(4).ToList()
            };
            return PartialView(footerVM);
        }
    }
}