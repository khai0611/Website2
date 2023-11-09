using GioiThieuSanPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GioiThieuSanPham.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            var ListProduct = new GioiThieuSanPham.Models.ProductModel().ListModel();
            return View(ListProduct);
        }

        public ActionResult ProductInfo(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult FindCategory(string namecategory, int? page)
        {
            ViewBag.namecategory = namecategory;
            ViewBag.page = page??1;
            return View();
        }

        public ActionResult AddProduct()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public ActionResult SaveNewProduct(ProductModel model, string active)
        {
            //If ID == 0 => Shows error of not entering ID and return page Add Product
            if(model.ID == 0)
            {
                ModelState.AddModelError("", "error of not entering ID");
                return RedirectToAction("AddProduct");
            }
            else
            {

            }
            return View(model);
        }
    }
}