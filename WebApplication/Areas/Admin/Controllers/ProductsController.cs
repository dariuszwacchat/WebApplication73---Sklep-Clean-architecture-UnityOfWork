using Application;
using Application.Services.Abs;
using Data;
using Data.Services;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.PhotosProduct;
using Domain.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ProductsController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly HtmlSanitizationService _htmlSanitizationService;

        public ProductsController (IUnityOfWork unityOfWork, HtmlSanitizationService htmlSanitizationService)
        {
            _unityOfWork = unityOfWork;
            _htmlSanitizationService = htmlSanitizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index (ProductsViewModel model)
        {
            NI.Navigation = Navigation.ProductsIndex;
            var products = await _unityOfWork.ProductsRepository.GetAll ();

            return View(new ProductsViewModel()
            {
                Products = products,
                Paginator = Paginator<Product>.CreateAsync(products, model.PageIndex, model.PageSize),
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
        public async Task<IActionResult> Index (string s, ProductsViewModel model)
        {
            var products = await _unityOfWork.ProductsRepository.GetAll ();


            // Wyszukiwanie
            if (!string.IsNullOrEmpty(model.q))
                products = products.Where(w => w.Name.Contains(model.q, StringComparison.OrdinalIgnoreCase)).ToList();


            // Sortowanie 
            switch (model.SortowanieOption)
            {
                case "Nazwa A-Z":
                    products = products.OrderBy(o => o.Name).ToList();
                    break;

                case "Nazwa Z-A":
                    products = products.OrderByDescending(o => o.Name).ToList();
                    break;

                case "Cena rosnąco":
                    products = products.OrderBy(o => o.Price).ToList();
                    break;

                case "Cena malejąco":
                    products = products.OrderByDescending(o => o.Price).ToList();
                    break;

                case "Odwiedziny rosnąco":
                    products = products.OrderBy(o => o.IloscOdwiedzin).ToList();
                    break;

                case "Odwiedziny malejąco":
                    products = products.OrderByDescending(o => o.IloscOdwiedzin).ToList();
                    break;
            }

            model.Products = products;
            model.Paginator = Paginator<Product>.CreateAsync(products, model.PageIndex, model.PageSize);
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            NI.Navigation = Navigation.ProductsCreate;

            ViewData["markiIdList"] = new SelectList(await _unityOfWork.MarkiRepository.GetAll(), "MarkaId", "Name");
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName");
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName");
            ViewData["subsubcategoriesIdList"] = new SelectList(await _unityOfWork.SubsubcategoriesRepository.GetAll(), "SubsubcategoryId", "FullName");

            return View(new CreateProductViewModel() { Result = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string sanitizedHtml = _htmlSanitizationService.SanitizeHtml(model.Description);
                model.Description = sanitizedHtml;

                if ((await _unityOfWork.ProductsRepository.Create(model)).Success)
                    return RedirectToAction("Index", "Products");
            }
             

            ViewData["markiIdList"] = new SelectList(await _unityOfWork.MarkiRepository.GetAll(), "MarkaId", "Name", model.MarkaId);
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", model.CategoryId);
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll (), "SubcategoryId", "FullName", model.SubcategoryId);
            ViewData["subsubcategoriesIdList"] = new SelectList(await _unityOfWork.SubsubcategoriesRepository.GetAll (), "SubsubcategoryId", "FullName", model.SubsubcategoryId);

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit (string id)
        {
            NI.Navigation = Navigation.ProductsEdit;

            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var product = await _unityOfWork.ProductsRepository.Get (id);

            if (product == null)
                return View("NotFound");

            ViewData["markiIdList"] = new SelectList(await _unityOfWork.MarkiRepository.GetAll(), "MarkaId", "Name", product.ProductId);
            ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", product.CategoryId);
            ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName", product.SubcategoryId);
            ViewData["subsubcategoriesIdList"] = new SelectList(await _unityOfWork.SubsubcategoriesRepository.GetAll(), "SubsubcategoryId", "FullName", product.SubsubcategoryId);

            return View(new EditProductViewModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Dostepnosc = product.Dostepnosc,
                Kolor = product.Kolor,
                MarkaId = product.MarkaId,
                PhotosProduct = product.PhotosProduct,
                Price = product.Price,
                Quantity = product.Quantity.ToString(),
                Rozmiar = product.Rozmiar,
                Znizka = product.Znizka, 
                CategoryId = product.CategoryId,
                SubcategoryId = product.SubcategoryId,
                SubsubcategoryId = product.SubsubcategoryId
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _unityOfWork.ProductsRepository.Update (model)).Success) 
                    return RedirectToAction("Index", "Products"); 
            }

            var product = await _unityOfWork.ProductsRepository.Get (model.ProductId);
            if (product != null)
            {
                ViewData["markiIdList"] = new SelectList(await _unityOfWork.MarkiRepository.GetAll(), "MarkaId", "Name", product.ProductId);
                ViewData["categoriesIdList"] = new SelectList(await _unityOfWork.CategoriesRepository.GetAll(), "CategoryId", "FullName", product.CategoryId);
                ViewData["subcategoriesIdList"] = new SelectList(await _unityOfWork.SubcategoriesRepository.GetAll(), "SubcategoryId", "FullName", product.SubcategoryId);
                ViewData["subsubcategoriesIdList"] = new SelectList(await _unityOfWork.SubsubcategoriesRepository.GetAll(), "SubsubcategoryId", "FullName", product.SubsubcategoryId);

            }

            return View(model);
        }

          

        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            var product = await _unityOfWork.ProductsRepository.Get (id);

            if (product == null)
                return View("NotFound");

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("NotFound");

            await _unityOfWork.ProductsRepository.Delete(id);

            return RedirectToAction("Index", "Products");
        }



        [HttpGet]
        public async Task<IActionResult> DeletePhotoProduct (string productId, string photoProductId)
        {
            if (string.IsNullOrEmpty(photoProductId))
                return View("NotFound");

            await _unityOfWork.PhotosProductRepository.DeletePhotoProductByProductId(productId, photoProductId);

            return RedirectToAction("Edit", "Products", new { id = productId });
        }



        /* private async Task CreateNewPhoto (List<IFormFile> files, string productId)
         {
             try
             {
                 if (files != null && files.Count > 0)
                 {
                     foreach (var file in files)
                     {
                         if (file.Length > 0)
                         {
                             byte [] photoData;
                             using (var stream = new MemoryStream())
                             {
                                 file.CopyTo(stream);
                                 photoData = stream.ToArray();
                             }

                             await _unityOfWork.PhotosProductRepository.Create ()

                             PhotoProduct photoProduct = new PhotoProduct ()
                             {
                                 PhotoProductId = Guid.NewGuid ().ToString (),
                                 PhotoData = photoData,
                                 ProductId = productId
                             };
                             _context.PhotosProduct.Add(photoProduct);
                             await _context.SaveChangesAsync();
                         }
                     }
                 }
             }
             catch { }
         }
 */



    }
}
