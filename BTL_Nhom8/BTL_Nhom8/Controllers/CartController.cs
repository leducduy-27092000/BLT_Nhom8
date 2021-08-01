using BTL_Nhom8.Dto;
using BTL_Nhom8.Helper;
using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_Nhom8.Controllers
{

    public class CartController : Controller
    {

        // GET: Cart
        private WebCayCanh db = new WebCayCanh();
        private const string CartSession = "CartSession";

        public ActionResult Index()
        {

            if (Session["HoTen"] == null)
            {
                Session["url-redirect"] = Request.Url.AbsoluteUri;
                return Redirect("/Home/Login");
            }
            var cart = (Cart)Session[CartSession];
            if (cart == null || cart.cartLines.Count == 0)
            {
                ViewBag.Message = "Giỏ hàng trống";
            }
            return View(cart);

        }

        [MyFilter]
        public ActionResult AddItem(int quantity, int product_Id)
        {

            if (Session["HoTen"] == null)
            {

                return Redirect("/Home/Login");
            }
            else
            {
                /*int quantity = Convert.ToInt32(HttpContext.Request.Form["quantity"]);
                int product_Id = Convert.ToInt32(HttpContext.Request.Form["Product_Id"]);*/
                var cart = (Cart)Session[CartSession];
                if (cart == null)
                {
                    cart = new Cart();
                }

                if (cart.cartLines.Exists(x => x.productDto.Id == product_Id))
                {
                    foreach (var item in cart.cartLines)
                    {
                        if (item.productDto.Id == product_Id)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    Product product = db.Products.Find(product_Id);
                    ProductDto productDto = new ProductDto(product);
                    CartItem cartItem = new CartItem();
                    cartItem.productDto = productDto;
                    cartItem.quantity += quantity;
                    cart.cartLines.Add(cartItem);
                }
                Session[CartSession] = cart;
                Session["CartLineTotal"] = cart.cartLines.Count();
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditItem(int id, int quantity)
        {
            var cart = (Cart) Session[CartSession];
            double sl = 0;
            foreach(var item in cart.cartLines)
            {
                if (item.productDto.Id.Equals(id))
                {
                    item.quantity = quantity;
                    sl = item.getAmount();
                    break;
                }
            }

            return Json(new
            {
                status = true, sl
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteItem(int id)
        {
            var cart = (Cart)Session[CartSession];

            var item = cart.cartLines.Find(p => p.productDto.Id.Equals(id));
            if(item != null)
            {
                cart.cartLines.Remove(item);
            }
            Session[CartSession] = cart;
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = (Cart)Session[CartSession];
            if (cart == null || cart.cartLines.Count == 0)
            {
                return RedirectToAction("index");
            }
            int id_user =(int) Session["idUser"];
            Account acc = (Account)db.Accounts.Where(a => a.Account_Id.Equals(id_user)).First() ;
            cart.customerDto = new CustomerDto(acc);
            return View(cart);
        }

        [HttpPost]
        public ActionResult Final_Checkout(CustomerDto customerDto)
        {
            var cart = (Cart)Session[CartSession];
            Order order = new Order();
            order.Account_Id = (int)Session["idUser"];
            order.Customer_Address= customerDto.Address;
            order.Customer_Phone = customerDto.Telephone;
            order.Status = true;
            order.Order_Date = DateTime.Now;
            order.Total_Amount = ((long)cart.cartLines.Sum(x => x.getAmount()));
            db.Orders.Add(order);
            db.SaveChanges();
            Session.Remove(CartSession);
            return View(cart);
        }
    }
}