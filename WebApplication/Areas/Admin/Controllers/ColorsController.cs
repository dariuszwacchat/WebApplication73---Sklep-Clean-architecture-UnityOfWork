using Application.Services.Abs;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.Colors;
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
    public class ColorsController : Controller
    {
        private readonly IColorsService _colorsService;

        public ColorsController (IColorsService colorsService)
        {
            _colorsService = colorsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index (ColorsViewModel model)
        {
            NI.Navigation = Navigation.ColorsIndex;
            var colors = await _colorsService.GetAll ();

            return View(new ColorsViewModel()
            {
                Colors = colors,
                Paginator = Paginator<Color>.CreateAsync(colors, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, ColorsViewModel model)
        {
            var colors = await _colorsService.GetAll ();

            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                colors = colors.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    colors = colors.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    colors = colors.OrderByDescending(o => o.Name).ToList();
                    break; 
            }

            model.Colors = colors;
            model.Paginator = Paginator<Color>.CreateAsync(colors, model.PageIndex, model.PageSize);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            NI.Navigation = Navigation.ColorsCreate;
            return View(new CreateColorViewModel() { Result = "" });
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _colorsService.Create(model)).Success)
                    return RedirectToAction("Index", "Colors");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit (string colorId)
        {
            NI.Navigation = Navigation.ColorsEdit;
            var color = await _colorsService.Get (colorId);

            if (color == null)
                return View("NotFound");

            return View(new EditColorViewModel()
            {
                ColorId = color.ColorId,
                Name = color.Name,
                Result = ""
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _colorsService.Update(model)).Success)
                    return RedirectToAction("Index", "Colors");
            }

            return View(model);
        } 


        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            var color = await _colorsService.Get (id);

            if (color == null)
                return View("NotFound");

            return View(color);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            await _colorsService.Delete(id);
            return RedirectToAction("Index", "Clients");
        }
    }
}
