using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laptop_Ecommerce.Models;
using Microsoft.AspNet.Identity;
using ApplicationDbContext = Laptop_Ecommerce.Data.ApplicationDbContext;

namespace Laptop_Ecommerce.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        private readonly CartService cartService;

        public ProductsController()
        {
            // Get the cartService from the Owin context
            var context = System.Web.HttpContext.Current.GetOwinContext();
            cartService = context.Get<CartService>("CartService");
        }



        public ActionResult Details(int id)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound(); // Or any other appropriate action for a not found product
            }


            return View(product);
        }


        public ActionResult AddToCart(int id, int quantity)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound(); // Or any other appropriate action for a not found product
            }


            var cartService = HttpContext.GetOwinContext().Get<CartService>("CartService");

            if (cartService == null)
            {
                // Handle null cartService, perhaps log the error or return an error response
                return Json(new { success = false, message = "Cart service is not available." });
            }

            var cartItem = new CartItemModel
            {
                ProductId = product.Id,
                UserId = User.Identity.GetUserId(),
                ProductName = product.Name,
                Quantity = quantity, // Initial quantity
                Price = product.Price,
                ImageUrl=product.ImageUrl,
            };

            cartService.AddToCart(cartItem);

            return Json(new { success = true, message = "Product added to cart successfully!" });
        }
    }
}