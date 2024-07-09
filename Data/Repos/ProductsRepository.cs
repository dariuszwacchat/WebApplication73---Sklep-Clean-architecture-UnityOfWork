using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.PhotosProduct;
using Domain.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductsRepository (ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetAll ()
        {
            return await _context.Products
                .Include(i => i.Category)
                .Include(i => i.Subcategory)
                .Include(i => i.Subsubcategory)
                .Include(i => i.ColorsProduct)
                .Include(i => i.PhotosProduct)
                .Include(i => i.SizesProduct)
                .Include(i => i.Marka)
                .OrderByDescending (o => o.DataDodania)
                .ToListAsync();
        }

        public async Task<Product> Get (string id)
        {
            return await _context.Products
                .Include(i => i.Category)
                .Include(i => i.Subcategory)
                .Include(i => i.Subsubcategory)
                .Include(i => i.ColorsProduct)
                .Include(i => i.PhotosProduct)
                .Include(i => i.SizesProduct)
                .Include(i => i.Marka)
                .OrderBy(o => o.DataDodania)
                .FirstOrDefaultAsync(f => f.ProductId == id);
        }


        public async Task<CreateProductViewModel> Create (CreateProductViewModel model)
        {
            /*if (model != null)
            {*/
               /* try
                {*/
                    Product product = new Product ()
                    {
                        ProductId = Guid.NewGuid ().ToString (),
                        Name = model.Name,
                        Description = model.Description,
                        MarkaId = model.MarkaId,
                        Kolor = model.Kolor,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        Rozmiar = model.Rozmiar,
                        Dostepnosc = model.Dostepnosc,
                        IloscOdwiedzin = 0,
                        CategoryId = model.CategoryId,
                        SubcategoryId = model.SubcategoryId,
                        SubsubcategoryId = model.SubsubcategoryId,
                        Znizka = model.Znizka,
                        DataDodania = DateTime.Now
                    };
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    //model.PhotosProduct = _context.ph

            // dodanie zdjęcia
            await CreateNewPhoto (model.Files, product.ProductId);


                    model.Success = true;
            /*}
            catch (Exception ex)
            {
                model.Result = "Catch exception.";
            }*/
            /* }
             else
             {
                 model.Result = "Model is null.";
             }*/
            return model;
        }



        public async Task<EditProductViewModel> Update (EditProductViewModel model)
        {
            /*if (model != null)
            {
                try
                {*/
                    var product = await _context.Products.FirstOrDefaultAsync (f=> f.ProductId == model.ProductId);
                    if (product != null)
                    {
                        product.Name = model.Name;
                        product.Description = model.Description;
                        product.MarkaId = model.MarkaId;
                        product.Kolor = model.Kolor;
                        product.Price = model.Price;
                        product.Quantity = model.Quantity;
                        product.Rozmiar = model.Rozmiar;
                        product.Dostepnosc = model.Dostepnosc;
                        product.IloscOdwiedzin = 0;
                        product.CategoryId = model.CategoryId;
                        product.SubcategoryId = model.SubcategoryId;
                        product.SubsubcategoryId = model.SubsubcategoryId;
                        product.Znizka = model.Znizka;

                        _context.Entry(product).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        //model.PhotosProduct = _context.PhotosProduct.Where (w=> w.ProductId == product.ProductId).ToList ();


                // dodanie zdjęcia
                await CreateNewPhoto(model.Files, product.ProductId);


                model.Success = true;
                    }
                    /*else
                    {
                        model.Result = "Product is null.";
                    }
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Model is null.";
            }*/
            return model;
        }



        public async Task<bool> Delete (string id)
        {
            bool deleteResult = false;
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync (f=>f.ProductId == id);
                if (product != null)
                {
                    // delete photos 
                    var photos = await _context.PhotosProduct.Where (w=> w.ProductId == product.ProductId).ToListAsync();
                    foreach (var photo in photos) 
                        _context.PhotosProduct.Remove(photo); 

                    // delete colors 
                    var colors = await _context.ColorsProduct.Where (w=> w.ProductId == product.ProductId).ToListAsync();
                    foreach (var color in colors) 
                        _context.ColorsProduct.Remove(color); 

                    // delete sizes
                    var rozmiary = await _context.SizesProduct.Where (w=> w.ProductId == product.ProductId).ToListAsync();
                    foreach (var rozmiar in rozmiary) 
                        _context.SizesProduct.Remove(rozmiar); 

                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    deleteResult = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            return deleteResult;
        }



        private async Task CreateNewPhoto (List<IFormFile> files, string productId)
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

    }
}
