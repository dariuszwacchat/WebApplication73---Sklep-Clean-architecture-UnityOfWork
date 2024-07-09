using Application.Services;
using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Marki;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class MarkiController : Controller
    {
        private readonly IMarkiService _markiService;

        public MarkiController (IMarkiService markiService)
        {
            _markiService = markiService;
        }


        [HttpGet]
        public async Task<IActionResult> Index (MarkiViewModel model)
        {
            NI.Navigation = Navigation.MarkiIndex;
            var marki = await _markiService.GetAll ();

            return View(new MarkiViewModel()
            {
                Marki = marki,
                Paginator = Paginator<Marka>.CreateAsync(marki, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, MarkiViewModel model)
        {
            var marki = await _markiService.GetAll ();


            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                marki = marki.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    marki = marki.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    marki = marki.OrderByDescending(o => o.Name).ToList();
                    break;
            }

            model.Marki = marki;
            model.Paginator = Paginator<Marka>.CreateAsync(marki, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create ()
        {
            NI.Navigation = Navigation.MarkiCreate;
            return View(new CreateMarkaViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateMarkaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _markiService.Create (model)).Success)
                    return RedirectToAction ("Index", "Marki");
            }
            return View(model);
        }


        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.MarkiEdit;

            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var marka = await _markiService.Get (id);

            if (marka == null)
                return View("NotFound");

            return View(new EditMarkaViewModel()
            {
                MarkaId = marka.MarkaId,
                Name = marka.Name,
                Result = ""
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditMarkaViewModel model)
        {
            if (string.IsNullOrEmpty(model.MarkaId))
                return View("NotFound");

            if (ModelState.IsValid)
            {
                if ((await _markiService.Update (model)).Success)
                    return RedirectToAction("Index", "Marki");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var marka = await _markiService.Get (id);

            if (marka == null)
                return View("NotFound");

            return View(marka);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _markiService.Delete (id);

            return RedirectToAction("Index", "Marki");
        }
         

    }
}
