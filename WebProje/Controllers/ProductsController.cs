using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        WareHouseEntities db = new WareHouseEntities();
        public ActionResult ProductList()
        {
            return View(db.Product.ToList());
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Product.Add(product);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine(ex);
                }
                return RedirectToAction("ProductList");
            
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = db.Product.SingleOrDefault(s => s.ProductID == id);
            db.Product.Remove(product);
            db.SaveChanges();
            ViewBag.message = "Product with name " + product.Name + " Deleted successfully";
            return View(product);
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = db.Product.SingleOrDefault(s => s.ProductID == id);

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            Product product_update = db.Product.SingleOrDefault(s => s.ProductID == product.ProductID);
            product_update.Name = product.Name;
            product_update.Amount = product.Amount;
            product_update.ProductType = product.ProductType;
            db.SaveChanges();

            ViewBag.Message = "Product updated successfully.";

            return View(product_update);
        }
    }
}