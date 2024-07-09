using Application.Services;
using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Sizes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class SizesController : Controller
    {
        private readonly ISizesService _sizesService;

        public SizesController (ISizesService sizesService)
        {
            _sizesService = sizesService;
        }


        [HttpGet]
        public async Task<IActionResult> Index (SizesViewModel model)
        {
            NI.Navigation = Navigation.SizesIndex;
            var sizes = await _sizesService.GetAll ();

            return View(new SizesViewModel()
            {
                Sizes = sizes,
                Paginator = Paginator<Size>.CreateAsync(sizes, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, SizesViewModel model)
        {
            var sizes = await _sizesService.GetAll ();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                sizes = sizes.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();



            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Rozmiar rosnąco":
                    sizes = sizes.OrderBy(o => o.Name).ToList();
                    break;

                case "Rozmiar malejąco":
                    sizes = sizes.OrderByDescending(o => o.Name).ToList();
                    break;
            }

            model.Sizes = sizes;
            model.Paginator = Paginator<Size>.CreateAsync(sizes, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create ()
        {
            NI.Navigation = Navigation.SizesCreate;
            return View(new CreateSizeViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateSizeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _sizesService.Create(model)).Success)
                    return RedirectToAction("Index", "Sizes");
            }
            return View(model);
        }


        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.SizesEdit;

            var size = await _sizesService.Get (id);

            if (size == null)
                return View("NotFound");

            return View(new EditSizeViewModel ()
            {
                SizeId = size.SizeId,
                Name = size.Name,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditSizeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _sizesService.Update(model)).Success)
                    return RedirectToAction("Index", "Sizes");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            var rozmiar = await _sizesService.Get (id);

            if (rozmiar == null)
                return View("NotFound");

            return View(rozmiar);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            await _sizesService.Delete(id);

            return RedirectToAction("Index", "Sizes");
        }
    }
}
