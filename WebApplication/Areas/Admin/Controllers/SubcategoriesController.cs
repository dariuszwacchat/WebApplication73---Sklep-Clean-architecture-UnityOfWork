using Application.Services;
using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Subcategories;
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
    public class SubcategoriesController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;

        public SubcategoriesController (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Index (SubcategoriesViewModel model)
        {
            NI.Navigation = Navigation.SubcategoriesIndex;
            var subcategories = await _unityOfWork.SubcategoriesRepository.GetAll ();


            return View(new SubcategoriesViewModel()
            {
                Subcategories = subcategories,
                Paginator = Paginator<Subcategory>.CreateAsync(subcategories, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, SubcategoriesViewModel model)
        {
            var subcategories = await _unityOfWork.SubcategoriesRepository.GetAll ();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                subcategories = subcategories.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    subcategories = subcategories.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    subcategories = subcategories.OrderByDescending(o => o.Name).ToList();
                    break;
            }

            model.Subcategories = subcategories;
            model.Paginator = Paginator<Subcategory>.CreateAsync(subcategories, model.PageIndex, model.PageSize);
            return View(model);
        }

          


        [HttpGet]
        public async Task <IActionResult> Create ()
        {
            NI.Navigation = Navigation.SubcategoriesCreate;
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName");
            return View (new CreateSubcategoryViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateSubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            {  
                if ((await _unityOfWork.SubcategoriesRepository.Create (model)).Success)
                    return RedirectToAction ("Index", "Subcategories");
            }
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll (), "CategoryId", "FullName", model.CategoryId);
            return View(model);
        }

        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.SubcategoriesEdit;
            var subcategory = await _unityOfWork.SubcategoriesRepository.Get (id);
             
            if (subcategory == null)
                return View("NotFound");

            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll (), "CategoryId", "FullName", subcategory.CategoryId);

            return View(new EditSubcategoryViewModel()
            {
                SubcategoryId = subcategory.SubcategoryId,
                Name = subcategory.Name,
                FullName = subcategory.FullName,
                CategoryId = subcategory.CategoryId,
                Kolejnosc = subcategory.Kolejnosc,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditSubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _unityOfWork.SubcategoriesRepository.Update (model)).Success)
                    return RedirectToAction ("Index", "Subcategories");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            var subcategory = await _unityOfWork.SubcategoriesRepository.Get (id);

            if (subcategory == null)
                return View("NotFound");

            return View(subcategory);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            await _unityOfWork.SubcategoriesRepository.Delete (id);
            return RedirectToAction("Index", "Subcategories");
        }

         

    }
}
