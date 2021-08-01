using BTL_Nhom8.Dto;
using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_Nhom8.Controllers
{
    public class HomeController : Controller
    {
        private WebCayCanh db = new WebCayCanh();
        public ActionResult Index()
        { 
            
                
             return View();      
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {

                var user = db.Accounts.Where(u => u.Email.Equals(Email) &&
                 u.Password.Equals(Password)).ToList();
                if (user.Count > 0)
                {
                    Session["HoTen"] = user.FirstOrDefault().Customer_Name;
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["idUser"] = user.FirstOrDefault().Account_Id;
                    var url = Session["url-redirect"];
                    if (url!= null)
                    {
                        Session.Remove("url-redirect");
                        return Redirect(url.ToString());

                    }
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công";
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            

            return RedirectToAction("Login");
        }
    }
}