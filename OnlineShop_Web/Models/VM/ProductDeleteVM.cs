﻿using OnlineShop_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop_Web.Models.VM
{
    public class ProductDeleteVM
    {
        public ProductDeleteVM()
        {
            Product = new ProductDTO();
        }
        public ProductDTO Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
