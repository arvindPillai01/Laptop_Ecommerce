﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop_Ecommerce.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
