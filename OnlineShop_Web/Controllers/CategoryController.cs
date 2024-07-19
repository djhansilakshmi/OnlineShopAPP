using AutoMapper;
using OnlineShop_Utility;
using OnlineShop_Web.Models;
using OnlineShop_Web.Models.Dto;
using OnlineShop_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using OnlineShop_Web.Services;

namespace OnlineShop_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexCategory()
        {
            List<CategoryDTO> list = new();

            var response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _categoryService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
{
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategory(int categoryId)
{
            var response = await _categoryService.GetAsync<APIResponse>(categoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {

                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<CategoryUpdateDTO>(model));
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category updated successfully";
                var response = await _categoryService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryService.GetAsync<APIResponse>(categoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(CategoryDTO model)
        {
            
                var response = await _categoryService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction(nameof(IndexCategory));
                }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

    }
}
