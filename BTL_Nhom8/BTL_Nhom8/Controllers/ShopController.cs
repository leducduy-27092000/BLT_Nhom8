using BTL_Nhom8.DAO;
using BTL_Nhom8.Dto;
using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL_Nhom8.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private WebCayCanh db = new WebCayCanh();
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        [HttpGet]
        public ActionResult Index(int? page, int? Category_Id)
        {
            List<Product> products;
            if (Category_Id == null || Category_Id == 0)
            {
                products = db.Products.ToList();
            }
            else products = categoriesDAO.GetProductsByCategoryId(Category_Id);
            List<Category> categories = categoriesDAO.GetAllCategoiries();
            ViewBag.categories = categories;
            
            ViewBag.current_Cate = Category_Id;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.TotalProducts = db.Products.ToList().Count;
            return View(products.ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public ActionResult Shop_Detail(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            Product product = db.Products.Find(id);
            product.Product_Image = db.Product_Image.Where(pi => pi.Product_Id == id).ToList();
            
            var splq = db.Products.Where(p => p.Category_Id.Equals(product.Category_Id)
            && p.Product_Id != id).Take(4).ToList();
            ViewBag.sqlq =(List<Product>) splq;
            return View(product);
        }

        
    }
}