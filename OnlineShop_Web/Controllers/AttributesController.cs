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

namespace OnlineShop_Web.Controllers
{
    public class AttributesController : Controller
    {
        private readonly IAttributesService _attributesService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public AttributesController(IAttributesService attributesService, IMapper mapper, IProductService productService)
        {
			_attributesService = attributesService;
            _mapper = mapper;
			_productService = productService;
        }

        public async Task<IActionResult> IndexAttributes(int productId)
        {
            List<AttributesDTO> list = new();
            ProductDTO productDTO;
            var res = await _productService.GetAsync<APIResponse>(productId, HttpContext.Session.GetString(SD.SessionToken));
            productDTO = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(res.Result));
            TempData["ProductId"] = productDTO.ProductId;
            TempData["CategoryId"] = productDTO.CategoryID;

            var response = await _attributesService.GetAllAsync<APIResponse>(productId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            { 
                list = JsonConvert.DeserializeObject<List<AttributesDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAttributes(int productId)
        {
            AttributesCreateVM attributesVM = new();
			ProductDTO productDTO;
			var response = await _productService.GetAsync<APIResponse>(productId, HttpContext.Session.GetString(SD.SessionToken));
			productDTO = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
			TempData["ProductId"] = productDTO.ProductId;
            attributesVM.Attributes.ProductId = productId;
			return View(attributesVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAttributes(AttributesCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _attributesService.CreateAsync<APIResponse>(model.Attributes, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexAttributes),new { productId = model.Attributes.ProductId });
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }          
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAttributes(int attributeId)
        {
			AttributesUpdateVM attributesVM = new();
            var response = await _attributesService.GetAsync<APIResponse>(attributeId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
				AttributesDTO model = JsonConvert.DeserializeObject<AttributesDTO>(Convert.ToString(response.Result));
				attributesVM.Attributes = _mapper.Map<AttributesUpdateDTO>(model);
            }

            TempData["ProductId"] = attributesVM.Attributes.ProductID;
           
            return View(attributesVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAttributes(AttributesUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _attributesService.UpdateAsync<APIResponse>(model.Attributes, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexAttributes), new { productId = model.Attributes.ProductID });
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAttributes(int attributeId)
        {
            AttributesDeleteVM attributesVM = new();
            var response = await _attributesService.GetAsync<APIResponse>(attributeId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                AttributesDTO model = JsonConvert.DeserializeObject<AttributesDTO>(Convert.ToString(response.Result));
                attributesVM.attribute = model;
            }

            TempData["ProductId"] = attributesVM.attribute.ProductID;
            return View(attributesVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttributes(AttributesDeleteVM model)
        {

            var response = await _attributesService.DeleteAsync<APIResponse>(model.attribute.AttributeId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexAttributes), new { productId = model.attribute.ProductID });
            }

            return View(model);
        }

    }
}
