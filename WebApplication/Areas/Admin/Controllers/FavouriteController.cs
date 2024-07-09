using Application.Services;
using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.ViewModels.Favourites;
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
    public class FavouriteController : Controller
    {
        private readonly IFavouritesService _favouritesService;

        public FavouriteController (IFavouritesService favouritesService)
        {
            _favouritesService = favouritesService;
        }


        [HttpGet]
        public async Task<IActionResult> Index (FavouritesViewModel model)
        {
            var favourites = await _favouritesService.GetAll ();

            return View(new FavouritesViewModel()
            {
                Favourites = favourites,
                Paginator = Paginator<Favourite>.CreateAsync(favourites, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, FavouritesViewModel model)
        {
            var favourites = await _favouritesService.GetAll ();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    favourites = favourites.OrderBy(o => o.Product.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    favourites = favourites.OrderByDescending(o => o.Product.Name).ToList();
                    break;
            }

            model.Favourites = favourites;
            model.Paginator = Paginator<Favourite>.CreateAsync(favourites, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            return View(new CreateFavouriteViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateFavouriteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _favouritesService.Create(model)).Success)
                    return RedirectToAction("Index", "Favourites");
            }
            return View(model);
        }
         

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var category = await _favouritesService.Get (id);

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

            await _favouritesService.Delete(id);

            return RedirectToAction("Index", "Favourites");
        }

    }
}
