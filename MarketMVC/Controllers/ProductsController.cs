using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketMVC.DAL;
using MarketMVC.Models;
using MarketMVC.ViewModel;

namespace MarketMVC.Controllers
{
    public class ProductsController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            //View Model
            CreateProduct f2 = new CreateProduct() {
                Product = new Product()
            };
            return View(f2);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProduct f2)
        {
            //If UserUploaded File Is Not Empty Transform the File to Byte[]
            if (f2.Pic!=null)
            {
                f2.Product.Pic = Services.SaveImageToDatabase.UseMe(f2.Pic);
            }
            //Save to Database
            if (ModelState.IsValid)
            {
                db.Products.Add(f2.Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(f2);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //View Model For Edit
            EditProduct f2 = new EditProduct()
            {
                Product = product
            };
            return View(f2);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProduct f2)
        {
            //If Picture has changed in Edit Mode convert the new picture to byte[]
            if (!(f2.Pic == null))
            {
                f2.Product.Pic = Services.SaveImageToDatabase.UseMe(f2.Pic);
            }
            //Find The Product that you need to update
            Product product = db.Products.Find(f2.Product.ID);
            //Use Method EditMe to compare Old and New object and update the old one with the changes
            product = Services.EditProduct.EditMe(product, f2.Product);
            //Save to Database
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(f2);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
