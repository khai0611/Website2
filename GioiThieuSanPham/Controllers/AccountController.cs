using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GioiThieuSanPham.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }

        //Action receive data
        [HttpGet]
        public ActionResult LoginSystem(string userName, string passWord)
        {
            //Check username and password
            if (userName == "admin" && passWord == "123456")
            {
                //Redirect to account information 
                //1. Redirect by action in common Controller
                //return RedirectToAction("AccountInformation", new { name = 10, tel = "0987456123" });
                //2. Redirect by link
                return RedirectToAction("/Account/AccountInformation?name=qk&tel=0921654356");
            }

            return RedirectToAction("Login", new { Message = "Your username or password is invalid" });

        }

        public ActionResult AccountInformation(string name, string tel)
        {
            return View();
        }
    }
}