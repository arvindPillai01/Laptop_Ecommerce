using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop_Ecommerce.Models
{
    public class CartItemModel
    {
            public int ProductId { get; set; }
            public string UserId { get; set; }  // User Id
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }

    }
}