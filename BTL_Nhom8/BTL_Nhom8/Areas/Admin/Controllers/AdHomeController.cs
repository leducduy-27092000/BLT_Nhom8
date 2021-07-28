using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_Nhom8.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult Login()
        {
            return Redirect("/Home/Login");
        }
        public ActionResult Register()
        {
            return Redirect("/Home/Register");
        }
    }
}