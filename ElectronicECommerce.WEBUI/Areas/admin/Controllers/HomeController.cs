using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicECommerce.WEBUI.Areas.admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {

        Repository<Admin> repoAdmin = new Repository<Admin>();
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            ViewBag.rtnURL = ReturnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous]
        public ActionResult Login(string username, string pass, string returnUrl)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pass))
            {
                Admin admin = repoAdmin.GetBy(a => a.UserName == username && a.Password == pass);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                    Session["AdSoyad"] = admin.Name;
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/admin");
                }
                else
                {
                    ViewBag.Error = "Hatalı Kullanıcı Adı veya Şifre";
                }
            }
            else
            {
                ViewBag.Error = "Alanları Boş Geçilemez";
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}