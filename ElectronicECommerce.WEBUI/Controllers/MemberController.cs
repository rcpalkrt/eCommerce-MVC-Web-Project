using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.DAL.Contexts;
using ElectronicECommerce.WEBUI.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicECommerce.WEBUI.Controllers
{
    public class MemberController : Controller
    {
        Repository<Member> repoMember = new Repository<Member>();
        Repository<Address> repoAddress = new Repository<Address>();
        Repository<City> repoCity = new Repository<City>();
        Repository<District> repoDistrict = new Repository<District>();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string MailAddress, string Password)
        {
            if (!string.IsNullOrEmpty(MailAddress) && !string.IsNullOrEmpty(Password))
            {
                string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                Member member = repoMember.GetBy(a => a.MailAddress == MailAddress && a.Password == pass);
                if (member != null)
                {
                    Session["MemberID"] = member.ID;
                    Session["AdSoyad"] = member.Name + " " + member.SurName;
                    return Redirect("/");
                }
                else
                {
                    TempData["Hata"] = "Mail Adresi veya Şifre Hatalı";
                    return RedirectToAction("Index");
                }
            }
            else TempData["Hata"] = "Mail Adresi veya Şifre boş geçilemez";
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["AdSoyad"] = null;
            if(System.Web.HttpContext.Current.Request.Cookies["CKCart"] != null)
            {
                HttpCookie kuki = System.Web.HttpContext.Current.Request.Cookies["CKCart"];
                System.Web.HttpContext.Current.Response.Cookies.Remove("CKCart");
                kuki.Expires = DateTime.Now.AddDays(-10);
                kuki.Value = null;
                System.Web.HttpContext.Current.Response.SetCookie(kuki);
            }
            return Redirect("/");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateAccount(Member member)
        {
            if (!string.IsNullOrEmpty(member.Name) && !string.IsNullOrEmpty(member.SurName) && !string.IsNullOrEmpty(member.MailAddress)
                && !string.IsNullOrEmpty(member.PhoneNumber) && !string.IsNullOrEmpty(member.Password) && !string.IsNullOrEmpty(member.Password2))
            {
                if (repoMember.GetAll().Any(a => a.MailAddress == member.MailAddress))
                {
                    TempData["error1"] = "*Bu Mail Adresi Daha Önce Kullanılmış! Lütfen Farklı Bir Mail Adresi Girin.";
                    return Redirect("/Member/Index");
                }
                else
                {
                    if (member.Password == member.Password2)
                    {
                        member.LastDate = DateTime.Now;
                        member.LastIP = Request.UserHostAddress;
                        member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(member.Password, "MD5");
                        member.Password2 = FormsAuthentication.HashPasswordForStoringInConfigFile(member.Password2, "MD5");
                        repoMember.Add(member);

                        Session["AdSoyad"] = member.Name + " " + member.SurName;

                        return Redirect("/");
                    }
                    else
                    {
                        TempData["error1"] = "*Parolalar Uyuşmadı Tekrar Deneyin!";
                        return Redirect("/Member/Index");
                    }
                }
            }
            else
            {
                TempData["error1"] = "*Alanlar Boş Geçilemez!";
                return Redirect("/Member/Index");
            }
        }

        public ActionResult MemberAddress()
        {
            int memberID = Convert.ToInt32(Session["MemberID"].ToString());
            AddresVM addresVM = new AddresVM {
                addresses = repoAddress.GetAll().Where(w => w.MemberID == memberID).ToList(),
                cities = repoCity.GetAll().ToList()
            };

            return View(addresVM);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult MemberAddress(Address address)
        {
            repoAddress.Add(address);
            return RedirectToAction("MemberAddress");
        }

        public ActionResult AddressUpdate(int ID)
        {
            Address address = repoAddress.GetAll().Include(i => i.City).Include(i=>i.District).FirstOrDefault(f => f.ID == ID);
            AddresVM addresVM = new AddresVM {
                address = address,
                addresses = repoAddress.GetAll().Where(w => w.MemberID == address.MemberID).ToList(),
                cities = repoCity.GetAll().ToList()
            };
            return View(addresVM);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddressUpdate(Address model)
        {
            repoAddress.Update(model);
            return RedirectToAction("MemberAddress");
        }

    }
}