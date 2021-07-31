using BTL_Nhom8.DAO;
using BTL_Nhom8.Dto;
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
        private Model2 db = new Model2();
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

        [HttpGet]
        public ActionResult Shop_Detail(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            Product product = db.Products.Find(id);
            var splq = db.Products.Where(p => p.Category_Id.Equals(product.Category_Id)
            && p.Product_Id != id).Take(4).ToList();
            ViewBag.sqlq =(List<Product>) splq;
            return View(product);
        }

        
    }
}