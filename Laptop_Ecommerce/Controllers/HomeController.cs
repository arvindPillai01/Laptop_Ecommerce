using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laptop_Ecommerce.Models;
using Microsoft.AspNet.Identity;

namespace Laptop_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private Data.ApplicationDbContext _dbContext = new Data.ApplicationDbContext();

        public ActionResult Index()
        {
            List<ProductModel> products = _dbContext.Product.ToList();
            return View(products);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //checkout
        public ActionResult Checkout()
        {
            ViewBag.Message = "Your checkout page.";
            return View();
        }


        //cart


        private CartService GetCartService()
        {
            // Retrieve the cartService from Owin context
            return System.Web.HttpContext.Current.GetOwinContext().Get<CartService>("CartService");
        }

        private readonly CartService cartService;
        public ActionResult Cart()
        {
            // Ensure the user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if not logged in
            }

            var cartService = GetCartService();

            if (cartService == null)
            {
                return View(new List<CartItemModel>()); // Return an empty cart for now
            }

            var userId = User.Identity.GetUserId();
            var cartItems = cartService.GetCartItems(userId);
            return View(cartItems);
        }



    }
}   