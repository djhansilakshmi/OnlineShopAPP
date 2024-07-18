using AutoMapper;
using OnlineShop_Utility;
using OnlineShop_Web.Models;
using OnlineShop_Web.Models.Dto;
using OnlineShop_Web.Models.VM;
using OnlineShop_Web.Services;
using OnlineShop_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OnlineShop_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexProduct(int categoryId)
        {
            List<ProductDTO> list = new();
            TempData["CategoryId"] = categoryId;

			var response = await _productService.GetAllAsync<APIResponse>(categoryId,HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
}
            return View(list);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateProduct(int categoryId)
        {
            ProductCreateVM productVM = new();
            TempData["CategoryId"] = categoryId;            
            return View(productVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductCreateVM model)
        {
            model.Product.Attributes = new List<AttributesCreateDTO>()
            { new AttributesCreateDTO { Name = "Color", Value = "Silver" },
              new AttributesCreateDTO { Name = "Storage", Value = "512GB SSD" } };
            //if (ModelState.IsValid)
            //{
            
                var response = await _productService.CreateAsync<APIResponse>(model.Product, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct), new { categoryId = model.Product.CategoryID });
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            //}
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            ProductUpdateVM productVM = new();
            var response = await _productService.GetAsync<APIResponse>(productId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                productVM.Product =  _mapper.Map<ProductUpdateDTO>(model);
            }
            TempData["CategoryId"]  = productVM.Product.CategoryID;
            TempData["Name"] = productVM.Product.Name;
            TempData["Brand"] = productVM.Product.Brand;
            TempData["Description"] = productVM.Product.Description;
           
            response = await _productService.GetAllAsync<APIResponse>(productId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); 
                return View(productVM);
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(ProductUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _productService.UpdateAsync<APIResponse>(model.Product, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexProduct), new { categoryId = model.Product.CategoryID });
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _productService.GetAllAsync<APIResponse>(model.Product.CategoryID, HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(int productID)
        {
            ProductDeleteVM productVM = new();
            var response = await _productService.GetAsync<APIResponse>(productID, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                productVM.Product = model;
            }
            TempData["CategoryId"] = productVM.Product.CategoryID;
            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                productVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(productVM);
            }


            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDeleteVM model)
        {

            var response = await _productService.DeleteAsync<APIResponse>(model.Product.ProductId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                
                return RedirectToAction(nameof(IndexProduct), new { categoryId = model.Product.CategoryID });
            }

            return View(model);
        }

    }
}
