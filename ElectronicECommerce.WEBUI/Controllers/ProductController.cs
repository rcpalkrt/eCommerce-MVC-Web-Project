using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.WEBUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicECommerce.WEBUI.Controllers
{
   
    public class ProductController : Controller
    {
        Repository<Product> repoProduct = new Repository<Product>();
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<Brand> repoBrand = new Repository<Brand>();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int ID)
        {
            ProductVM productVM = new ProductVM();

            Product product = repoProduct.GetAll().FirstOrDefault(f=>f.ID==ID);
            productVM.detailProduct = product;
            productVM.relatedProducts = repoProduct.GetAll().Where(w => w.CategoryID == product.CategoryID).ToList();

            return View(productVM);
        }
        public ActionResult Categories()
        {
            ViewBag.MenuIndex = 2;
            ProductVM productVM = new ProductVM {
                products = repoProduct.GetAll().ToList(),
                categories = repoCategory.GetAll().Include(i=>i.Children).ToList(),
                brands = repoBrand.GetAll().Include(i=>i.Products).ToList()
            };
            return View(productVM);
        }
        public ActionResult Filter(int? catID, int? brID)
        {
            ProductVM productVM = new ProductVM
            {
                products = repoProduct.GetAll().ToList(),
                categories = repoCategory.GetAll().Include(i => i.Children).ToList(),
                brands = repoBrand.GetAll().Include(i => i.Products).ToList()
            };

            if (catID.HasValue)
            {
                productVM.products = repoProduct.GetAll().Where(w=>w.CategoryID == catID).ToList();
            }
            if(brID.HasValue)
            {
                productVM.products = repoProduct.GetAll().Where(w => w.BrandID == brID).ToList();
            }

            return View("Categories",productVM);
        }
    }
}