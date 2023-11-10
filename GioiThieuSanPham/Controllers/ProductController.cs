using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GioiThieuSanPham.Models;

namespace GioiThieuSanPham.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            ////Query all: Select * from Table
            //var KQ = (from item in db.Products select item).ToList();
            ////Query with condition: Select * from Table where <contidion>
            //var KQ1 = (from item in db.Products 
            //           where item.NewPrice <= 100
            //           select item).ToList();
            ////Arrange: select * from Table order by 
            //var KQ2 = (from item in db.Products
            //           orderby item.NewPrice
            //           select item).ToList();
            ////Connect between 2 table: Select * from Table1 inner join Table1.<key2> = Table2.<key2>
            //var KQ3 = (from item in db.Products
            //          join Manufacturer in db.Manufacturers
            //          on item.ManufacturerID equals Manufacturer.ID
            //          select new 
            //          { 
            //              item.ID,
            //              item.ProductName,
            //              Manufacturer.ManufacturerName,
            //          }
                          
            //          ).ToList();


            ////Filter duplicate products
            //var KQ4 = (from item in db.Products
            //           join Manufacturer in db.Manufacturers
            //           on item.ManufacturerID equals Manufacturer.ID
            //           select Manufacturer
            //           ).Distinct().ToList();

            // Take out the products
            List<Product> Result = db.Products.ToList();

            return View(Result);
        }

        public ActionResult ProductInfo(int ID)
        {
            //find this obj in db
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            Product Result = db.Products.Find(ID);

            return View(Result);
        }

        public ActionResult AddNew()
        {
            return View(new Product() { OldPrice = 0, NewPrice = 0 });
        }
        [HttpPost]

        public ActionResult AddNew(Product model)
        {
            //Save data to DB
            if (string.IsNullOrEmpty(model.ProductName) == true)
            {
                ModelState.AddModelError("", "Product name is not null");
                return View(model);
            }
            if (model.NewPrice <= 0)
            {
                ModelState.AddModelError("", "Price must be > 0");
                return View(model);
            }

            // Save
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();

            //Add function
            db.Products.Add(model);

            //Save data function
            db.SaveChanges();
            if (model.ID > 0)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Cannot save to DB");
                return View(model);
            }
        }

        public ActionResult Update(int id)
        {
            //Find product need to update
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var ProductModel = db.Products.Find(id);
            return View(ProductModel);
        }

        [HttpPost]
        public ActionResult Update(Product model)
        {
            //Save data to DB
            if (string.IsNullOrEmpty(model.ProductName) == true)
            {
                ModelState.AddModelError("", "Product name is not null");
                return View(model);
            }
            if (model.NewPrice <= 0)
            {
                ModelState.AddModelError("", "Price must be > 0");
                return View(model);
            }

            // Save
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            //1. Find the object to change
            var updateModel = db.Products.Find(model.ID);
            //2. Assign value to object
            updateModel.ProductName = model.ProductName;
            updateModel.Post = model.Post;
            updateModel.OldPrice = model.OldPrice;
            updateModel.NewPrice = model.NewPrice;
            updateModel.ManufacturerID = model.ManufacturerID;
            updateModel.Summary = model.Summary;

            var id = db.SaveChanges();
            if(id > 0)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Cannot save to DB");
                return View(model);
            }
        }

        public ActionResult Delete(int ID)
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var model = db.Products.Find(ID);
            db.Products.Remove(model);
            db.SaveChanges();

            return RedirectToAction("ProductList");
        }
    }
}