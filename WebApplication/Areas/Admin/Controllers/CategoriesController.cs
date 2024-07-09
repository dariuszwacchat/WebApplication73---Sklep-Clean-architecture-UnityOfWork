using Application.Services;
using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController (ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index (CategoriesViewModel model)
        { 
            NI.Navigation = Navigation.CategoriesIndex; 
            var categories = await _categoriesService.GetAll ();

            return View(new CategoriesViewModel()
            {
                Categories = categories,
                Paginator = Paginator<Category>.CreateAsync(categories, model.PageIndex, model.PageSize),
                PageIndex = model.PageIndex,
                PageSize = model.PageSize,
                Start = model.Start,
                End = model.End,
                q = model.q,
                SortowanieOption = model.SortowanieOption
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index (string s, CategoriesViewModel model)
        {
            var categories = await _categoriesService.GetAll ();


            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                categories = categories.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    categories = categories.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    categories = categories.OrderByDescending(o => o.Name).ToList();
                    break; 
            }

            model.Categories = categories;
            model.Paginator = Paginator<Category>.CreateAsync(categories, model.PageIndex, model.PageSize);
            return View(model);
        }
         

        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            NI.Navigation = Navigation.CategoriesCreate;
            return View(new CreateCategoryViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _categoriesService.Create (model)).Success)
                    return RedirectToAction("Index", "Categories");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.CategoriesEdit;

            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var category = await _categoriesService.Get (id);

            if (category == null)
                return View("NotFound");

            return View(new EditCategoryViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                FullName = category.FullName,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditCategoryViewModel model)
        {
            if (string.IsNullOrEmpty(model.CategoryId) || model == null)
                return View("NotFound");

            if (ModelState.IsValid)
            {
                if ((await _categoriesService.Update (model)).Success)
                    return RedirectToAction("Index", "Categories");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var category = await _categoriesService.Get (id);

            if (category == null)
                return View("NotFound");

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _categoriesService.Delete (id);

            return RedirectToAction("Index", "Categories");
        }
          


    }
}
