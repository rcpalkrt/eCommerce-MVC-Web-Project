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
    public class BrandController : Controller
    {
        Repository<Brand> repoBrand = new Repository<Brand>();

        public ActionResult Index()
        {
            return View(repoBrand.GetAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = repoBrand.GetBy(g=>g.ID==id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {           
            if (ModelState.IsValid)
            {
                repoBrand.Add(brand);
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: admin/Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = repoBrand.GetBy(g=>g.ID==id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: admin/Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                repoBrand.Update(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: admin/Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = repoBrand.GetBy(g=>g.ID==id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: admin/Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = repoBrand.GetBy(g => g.ID == id);
            repoBrand.Remove(brand);
            return RedirectToAction("Index");
        }
    }
}
