using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ElectronicECommerce.BLL.Respositories;
using ElectronicECommerce.BOL.Entities;
using ElectronicECommerce.WebUI.OtherModels;

namespace ElectronicECommerce.WebUI.Areas.admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        Repository<Product> repoProduct = new Repository<Product>();
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<Brand> repoBrand = new Repository<Brand>();
        Repository<Picture> repoPicture = new Repository<Picture>();

        public ActionResult Index()
        {
            return View(repoProduct.GetAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.GetBy(g => g.ID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            ManyClass manyClass = new ManyClass
            {
                Product = new Product(),
                Categories = repoCategory.GetAll().ToList(),
                Brands = repoBrand.GetAll().ToList()
            };
            return View(manyClass);
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create(ManyClass model, List<HttpPostedFileBase> Picture)
        {
            if (ModelState.IsValid)
            {
                // minumum bir resim secildiyse(ilk resim)
                if (Picture[0] != null)
                {
                    int pindex = 1;
                    repoProduct.Add(model.Product);
                    foreach (var picture in Picture)
                    {
                        if (picture != null)
                        {
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-cart"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-cart"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-details"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-details"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-last-slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-last-slider"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-slider"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/Temporary"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/Temporary"));
                            
                            picture.SaveAs(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));

                            Bitmap imgCart = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeCart = new Size(102, 123);
                            Bitmap imgCart1 = new Bitmap(imgCart, sizeCart);
                            imgCart1.Save(Server.MapPath("~/Content/img/product/product-cart/" + picture.FileName), ImageFormat.Jpeg);
                            imgCart.Dispose();
                            imgCart1.Dispose();

                            Bitmap imgDetails = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeDetails = new Size(78, 104);
                            Bitmap imgDetails1 = new Bitmap(imgDetails, sizeDetails);
                            imgDetails1.Save(Server.MapPath("~/Content/img/product/product-details/" + picture.FileName), ImageFormat.Jpeg);
                            imgDetails.Dispose();
                            imgDetails1.Dispose();

                            Bitmap imgLastSlider = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeLastSlider = new Size(270, 320);
                            Bitmap imgLastSlider1 = new Bitmap(imgLastSlider, sizeLastSlider);
                            imgLastSlider1.Save(Server.MapPath("~/Content/img/product/product-last-slider/" + picture.FileName), ImageFormat.Jpeg);
                            imgLastSlider.Dispose();
                            imgLastSlider1.Dispose();

                            Bitmap imgSlider = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeSlider = new Size(384, 660);
                            Bitmap imgSlider1 = new Bitmap(imgSlider, sizeSlider);
                            imgSlider1.Save(Server.MapPath("~/Content/img/product/product-slider/" + picture.FileName), ImageFormat.Jpeg);
                            imgSlider.Dispose();
                            imgSlider1.Dispose();

                            repoPicture.Add(new Picture
                            {
                                PIndex = pindex,
                                ProductID = model.Product.ID,
                                PCartPath = "/Content/img/product/product-cart/" + picture.FileName,
                                PDetailPath = "/Content/img/product/product-details/" + picture.FileName,
                                PLastSliderPath = "/Content/img/product/product-last-slider/" + picture.FileName,
                                PSliderPath = "/Content/img/product/product-slider/" + picture.FileName
                            });
                            pindex++;
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model.Product);
        }

        // GET: admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.GetBy(g => g.ID == id);
            ManyClass manyClass = new ManyClass
            {
                Product = product,
                Categories = repoCategory.GetAll().Include(i=>i.Products).ToList(),
                Brands = repoBrand.GetAll().ToList()
            };
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(manyClass);
        }

        // POST: admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManyClass model, List<HttpPostedFileBase> Picture)
        {
            if (ModelState.IsValid)
            {
                //Resim seçilmediyse sadece Product tablosunda güncelleme yapar
                repoProduct.Update(model.Product);

                //Minumum bir resim secili ise(ilk resim).... <<Picture[1] = ikinci resim(input file'lardan ikincisi)>>
                if (Picture[0] != null)
                {
                    IList<Picture> silinecekResimler = repoPicture.GetAll().Where(w => w.ProductID == model.Product.ID).ToList();
                    // Dosyadan Silme
                    foreach (var picture in silinecekResimler)
                    {
                        if (System.IO.File.Exists(HttpContext.Server.MapPath(picture.PCartPath)))
                        {
                            System.IO.File.Delete(HttpContext.Server.MapPath(picture.PCartPath));
                        }
                    }
                    // Veritabanindan silme
                    repoPicture.RemoveRange(silinecekResimler);

                    // Yeni seçilen resimlelri Picture Tablosuna Ekleme 
                    int pindex = 1;
                    foreach (var picture in Picture)
                    {
                        if (picture != null)
                        {
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-cart"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-cart"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-details"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-details"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-last-slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-last-slider"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/product-slider"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/product-slider"));
                            if (!Directory.Exists(Server.MapPath("~/Content/img/product/Temporary"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/product/Temporary"));

                            picture.SaveAs(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));

                            Bitmap imgCart = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeCart = new Size(102, 123);
                            Bitmap imgCart1 = new Bitmap(imgCart, sizeCart);
                            imgCart1.Save(Server.MapPath("~/Content/img/product/product-cart/" + picture.FileName), ImageFormat.Jpeg);
                            imgCart.Dispose();
                            imgCart1.Dispose();

                            Bitmap imgDetails = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeDetails = new Size(78, 104);
                            Bitmap imgDetails1 = new Bitmap(imgDetails, sizeDetails);
                            imgDetails1.Save(Server.MapPath("~/Content/img/product/product-details/" + picture.FileName), ImageFormat.Jpeg);
                            imgDetails.Dispose();
                            imgDetails1.Dispose();

                            Bitmap imgLastSlider = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeLastSlider = new Size(270, 320);
                            Bitmap imgLastSlider1 = new Bitmap(imgLastSlider, sizeLastSlider);
                            imgLastSlider1.Save(Server.MapPath("~/Content/img/product/product-last-slider/" + picture.FileName), ImageFormat.Jpeg);
                            imgLastSlider.Dispose();
                            imgLastSlider1.Dispose();

                            Bitmap imgSlider = new Bitmap(Server.MapPath("~/Content/img/product/Temporary/" + picture.FileName));
                            Size sizeSlider = new Size(384, 660);
                            Bitmap imgSlider1 = new Bitmap(imgSlider, sizeSlider);
                            imgSlider1.Save(Server.MapPath("~/Content/img/product/product-slider/" + picture.FileName), ImageFormat.Jpeg);
                            imgSlider.Dispose();
                            imgSlider1.Dispose();

                            repoPicture.Add(new Picture
                            {
                                PIndex = pindex,
                                ProductID = model.Product.ID,
                                PCartPath = "/Content/img/product/product-cart/" + picture.FileName,
                                PDetailPath = "/Content/img/product/product-details/" + picture.FileName,
                                PLastSliderPath = "/Content/img/product/product-last-slider/" + picture.FileName,
                                PSliderPath = "/Content/img/product/product-slider/" + picture.FileName
                            });
                            pindex++;
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            return View(model.Product);
        }

        // GET: admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.GetBy(g => g.ID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Urun silinirse dosyadan ve Picture tablosundan da silinmeli
            IList<Picture> silinecekResimler = repoPicture.GetAll().Where(w => w.ProductID == id).ToList();
            // Dosyadan Silme
            foreach (var picture in silinecekResimler)
            {
                if (System.IO.File.Exists(HttpContext.Server.MapPath(picture.PCartPath)))
                {
                    System.IO.File.Delete(HttpContext.Server.MapPath(picture.PCartPath));
                }
            }
            // Veritabanindan silme
            repoPicture.RemoveRange(silinecekResimler);

            Product product = repoProduct.GetBy(g => g.ID == id);
            repoProduct.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
