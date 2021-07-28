using BTL_Nhom8.DAO;
using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BTL_Nhom8.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private Model1 db = new Model1();
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        [HttpGet]
        public ActionResult Index()
        {
            Shop(0);
            return View();
        }
 
        public ActionResult Category(int id)
        {
            Shop(id);
            return View("Index");
        }

        public void Shop(int id)
        {
            List<Product> products;
            if (id == 0)
            {
                products = db.Products.ToList();
            }
            else products = categoriesDAO.GetProductsByCategoryId(id);
            List<Category> categories = categoriesDAO.GetAllCategoiries();
            ViewBag.categories = categories;
            ViewBag.products = products;
            ViewBag.TotalProducts = db.Products.ToList().Count();
        }

        public ActionResult Shop_Detail()
        {
            return View();
        }
    }
}