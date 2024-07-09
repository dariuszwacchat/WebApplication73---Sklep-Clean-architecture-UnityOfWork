using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Subcategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public SubcategoriesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subcategory>> GetAll ()
        {
            return await _context.Subcategories
                .Include(i => i.Category)
                .Include(i => i.Subsubcategories)
                .OrderBy (o=> o.Kolejnosc)
                .ToListAsync();
        }

        public async Task<Subcategory> Get (string id)
        {
            return await _context.Subcategories
                .Include(i => i.Category)
                .Include(i => i.Subsubcategories)
                .OrderBy(o => o.Kolejnosc)
                .FirstOrDefaultAsync(f => f.SubcategoryId == id);
        }

        public async Task<CreateSubcategoryViewModel> Create (CreateSubcategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Subcategories.FirstOrDefaultAsync (f=> f.Name == model.Name)) == null)
                    {
                        Subcategory subcategory = new Subcategory ()
                        {
                            SubcategoryId = Guid.NewGuid ().ToString (),
                            Name = model.Name,
                            FullName = model.FullName,
                            CategoryId = model.CategoryId,
                            IloscOdwiedzin = 0,
                        };
                        _context.Subcategories.Add(subcategory);
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


        public async Task<EditSubcategoryViewModel> Update (EditSubcategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Subcategories.FirstOrDefaultAsync(f => f.Name == model.Name && f.SubcategoryId != model.SubcategoryId)) == null)
                    {
                        var subcategory = await _context.Subcategories.FirstOrDefaultAsync (f=> f.SubcategoryId == model.SubcategoryId);
                        if (subcategory != null)
                        {
                            subcategory.Name = model.Name;
                            subcategory.FullName = model.FullName;
                            subcategory.CategoryId = model.CategoryId;

                            _context.Entry(subcategory).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Subcategory is null.";
                        }
                    }
                    else
                    {
                        model.Result = "Wskazana nazwa kategorii już istnieje. Spróbuj podać inną nazwę";
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
                var subcategory = await _context.Subcategories.FirstOrDefaultAsync (f=>f.SubcategoryId == id);
                if (subcategory != null)
                {  
                    var products = await _context.Products
                        .Where (w=> w.SubcategoryId == id && w.CategoryId == subcategory.CategoryId)
                        .ToListAsync();

                    foreach (var product in products) 
                        _context.Products.Remove(product);  

                    _context.Subcategories.Remove(subcategory);
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
