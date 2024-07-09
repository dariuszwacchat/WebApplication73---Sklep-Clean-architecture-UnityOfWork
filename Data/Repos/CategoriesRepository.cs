using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context; 
        public CategoriesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll ()
        {
            return await _context.Categories
                .Include (i=> i.Subcategories) 
                .OrderBy (o=> o.Name)
                .ToListAsync();
        }

        public async Task<Category> Get (string id)
        {
            return await _context.Categories
                .Include(i => i.Subcategories)
                .FirstOrDefaultAsync(f => f.CategoryId == id);
        }

        public async Task<CreateCategoryViewModel> Create (CreateCategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Categories.FirstOrDefaultAsync (f=> f.Name == model.Name)) == null)
                    {
                        Category category = new Category ()
                        {
                            CategoryId = Guid.NewGuid ().ToString (),
                            Name = model.Name,
                            FullName = model.FullName,
                            IloscOdwiedzin = 0,
                            Photo = "",
                        };
                        _context.Categories.Add(category);
                        await _context.SaveChangesAsync(); 
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "Wskazana nazwa już istnieje.";
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
            }
            return model;
        }



        public async Task<EditCategoryViewModel> Update (EditCategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Categories.FirstOrDefaultAsync(f => f.Name == model.Name && f.CategoryId != model.CategoryId)) == null)
                    {
                        var category = await _context.Categories.FirstOrDefaultAsync (f=> f.CategoryId == model.CategoryId);
                        if (category != null)
                        {
                            category.Name = model.Name;
                            category.FullName = model.FullName; 

                            _context.Entry(category).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Category is null.";
                        }
                    }
                    else
                    {
                        model.Result = "Wskazana nazwa już istnieje.";
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
            }
            return model;
        }


        public async Task<bool> Delete (string id)
        {
            bool deleteResult = false;
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync (f=>f.CategoryId == id);
                if (category != null)
                {
                    // usunięcie subkategorii
                    var subcategories = await _context.Subcategories
                    .Where (w=> w.CategoryId == id)
                    .ToListAsync ();

                    foreach (var subcategory in subcategories) 
                        _context.Subcategories.Remove(subcategory);


                    // usunięcie subsubkategorii
                    var subsubcategories = await _context.Subsubcategories
                    .Where (w=> w.CategoryId == id)
                    .ToListAsync ();
                    foreach (var subsubcategory in subsubcategories) 
                        _context.Subsubcategories.Remove(subsubcategory);


                    // usunięcie produktów
                    var products = await _context.Products
                    .Where (w=> w.CategoryId == id)
                    .ToListAsync ();

                    foreach (var product in products) 
                        _context.Products.Remove(product);

                     
                    // usunięcie kategorii
                    _context.Categories.Remove(category);
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

         
    }

}
