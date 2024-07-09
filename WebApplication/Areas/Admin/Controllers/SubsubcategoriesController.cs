using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Subsubcategories;
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
    public class SubsubcategoriesController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;

        public SubsubcategoriesController (IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Index (SubsubcategoriesViewModel model)
        {
            NI.Navigation = Navigation.SubsubcategoriesIndex;
            var subsubcategories = await _unityOfWork.SubsubcategoriesRepository.GetAll ();

            return View(new SubsubcategoriesViewModel()
            {
                Subsubcategories = subsubcategories,
                Paginator = Paginator<Subsubcategory>.CreateAsync(subsubcategories, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, SubsubcategoriesViewModel model)
        {
            var subsubcategories = await _unityOfWork.SubsubcategoriesRepository.GetAll ();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                subsubcategories = subsubcategories.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    subsubcategories = subsubcategories.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    subsubcategories = subsubcategories.OrderByDescending(o => o.Name).ToList();
                    break;
            }

            model.Subsubcategories = subsubcategories;
            model.Paginator = Paginator<Subsubcategory>.CreateAsync(subsubcategories, model.PageIndex, model.PageSize);
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            NI.Navigation = Navigation.SubsubcategoriesCreate;
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName");
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName");

            return View(new CreateSubsubcategoryViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateSubsubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            { 
                if ((await _unityOfWork.SubsubcategoriesRepository.Create (model)).Success)
                    return RedirectToAction("Index", "Subsubcategories");
            }
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", model.CategoryId);
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName", model.SubcategoryId);
            return View(model);
        }
         
        [HttpGet]
        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.SubsubcategoriesEdit;
            var subsubcategory = await _unityOfWork.SubsubcategoriesRepository.Get (id);

            if (subsubcategory == null)
                return View("NotFound");

            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", subsubcategory.CategoryId);
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName", subsubcategory.SubcategoryId);

            return View(new EditSubsubcategoryViewModel()
            {
                SubsubcategoryId = subsubcategory.SubsubcategoryId,
                Name = subsubcategory.Name,
                FullName = subsubcategory.FullName,
                CategoryId = subsubcategory.CategoryId,
                SubcategoryId = subsubcategory.SubcategoryId,
                Kolejnosc = subsubcategory.Kolejnosc,
                Result = ""
            }); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditSubsubcategoryViewModel model)
        {  
            if (ModelState.IsValid)
            {
                if ((await _unityOfWork.SubsubcategoriesRepository.Update (model)).Success)
                    return RedirectToAction("Index", "Subsubcategories");
            }
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", model.CategoryId);
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName", model.SubcategoryId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            var subsubcategory = await _unityOfWork.SubsubcategoriesRepository.Get (id);

            if (subsubcategory == null)
                return View("NotFound");

            return View(subsubcategory);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            await _unityOfWork.SubsubcategoriesRepository.Delete (id);
            return RedirectToAction("Index", "Subsubcategories");
        }
         

    }
}
