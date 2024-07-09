using Application.Services;
using Application.Services.Abs;
using Domain.ViewModels.Koszyk;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [AllowAnonymous]
    public class KoszykController : Controller
    { 
        private readonly IProductsService _productsService;
        private readonly KoszykService _koszykService;

        public KoszykController (IProductsService productsService, KoszykService koszykService)
        {
            _productsService = productsService;
            _koszykService = koszykService;
        }

        [HttpGet]
        public IActionResult Index (KoszykViewModel model)
        {
            _koszykService.Update (model.KoszykItemId, model.Ilosc);
            model.KoszykItems = _koszykService.GetAll(); 
            return View(model);
        }


        // Akcja znajduje się w kontrolerze Products
        [HttpGet]
        public async Task <IActionResult> Create (string productId)
        {
            var product = await _productsService.Get (productId);
            if (product != null)
                _koszykService.Create(product);

            return RedirectToAction("Index", "Products");
        }


        [HttpGet]
        public IActionResult Delete (string koszykItemId)
        {
            _koszykService.Delete(koszykItemId);

            return RedirectToAction("Index", "Koszyk");
        }


    }
}
