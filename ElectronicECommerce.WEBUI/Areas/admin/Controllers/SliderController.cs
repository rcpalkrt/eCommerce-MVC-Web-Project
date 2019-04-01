using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;

namespace ElectronicECommerce.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class SliderController : Controller
    {
        Repository<Slider> repoSlider = new Repository<Slider>();

        public ActionResult Index()
        {
            return View(repoSlider.GetAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = repoSlider.GetBy(g=>g.ID==id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider,HttpPostedFileBase Picture)
        {           
            if (ModelState.IsValid)
            {
                if (Picture != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/Content/img/slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/slider"));
                    Picture.SaveAs(Server.MapPath("~/Content/img/slider/" + Picture.FileName));
                    slider.Picture = "/Content/img/slider/" + Picture.FileName;
                }
                repoSlider.Add(slider);
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: admin/Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = repoSlider.GetBy(g=>g.ID==id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider,HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                if (Picture != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/Content/img/slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/slider"));
                    Picture.SaveAs(Server.MapPath("~/Content/img/slider/" + Picture.FileName));
                    slider.Picture = "/Content/img/slider/" + Picture.FileName;
                }
                repoSlider.Update(slider);
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: admin/Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = repoSlider.GetBy(g=>g.ID==id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = repoSlider.GetBy(g => g.ID == id);
            repoSlider.Remove(slider);
            return RedirectToAction("Index");
        }
    }
}
