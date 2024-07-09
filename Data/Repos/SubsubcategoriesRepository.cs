using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Subsubcategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class SubsubcategoriesRepository : ISubsubcategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public SubsubcategoriesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subsubcategory>> GetAll ()
        {
            return await _context.Subsubcategories
                .Include(i => i.Products)
                .Include(i => i.Category)
                .Include(i => i.Subcategory)
                .OrderBy (o=> o.Name)
                .ToListAsync();
        }

        public async Task<Subsubcategory> Get (string id)
        {
            return await _context.Subsubcategories
                .Include(i => i.Products)
                .Include(i => i.Category)
                .Include(i => i.Subcategory)
                .OrderBy(o => o.Name)
                .FirstOrDefaultAsync(f => f.SubsubcategoryId == id);
        }

        public async Task<CreateSubsubcategoryViewModel> Create (CreateSubsubcategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Subsubcategories.FirstOrDefaultAsync(f => f.Name == model.Name)) == null)
                    {
                        Subsubcategory subsubcategory = new Subsubcategory ()
                        {
                            SubsubcategoryId = Guid.NewGuid ().ToString (),
                            Name = model.Name,
                            FullName = model.FullName,
                            CategoryId = model.CategoryId,
                            SubcategoryId = model.SubcategoryId
                        };
                        _context.Subsubcategories.Add(subsubcategory);
                        await _context.SaveChangesAsync();
                        model.Success = true;

                    }
                    else
                    {
                        model.Result = "Wskazana nazwa subsubkategorii już istnieje. Spróbuj podać inną nazwę";
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

        public async Task<EditSubsubcategoryViewModel> Update (EditSubsubcategoryViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Subsubcategories.FirstOrDefaultAsync(f => f.Name == model.Name && f.SubsubcategoryId != model.SubsubcategoryId)) == null)
                    {
                        var subsubcategory = await _context.Subsubcategories.FirstOrDefaultAsync (f=> f.SubsubcategoryId == model.SubsubcategoryId);
                        if (subsubcategory != null)
                        {
                            subsubcategory.Name = model.Name;
                            subsubcategory.FullName = model.FullName;
                            subsubcategory.CategoryId = model.CategoryId;
                            subsubcategory.SubcategoryId = model.SubcategoryId;

                            _context.Entry(subsubcategory).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Subsubcategory is null.";
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
                var subsubcategory = await _context.Subsubcategories.FirstOrDefaultAsync (f=>f.SubsubcategoryId == id);
                if (subsubcategory != null)
                {
                    _context.Subsubcategories.Remove(subsubcategory);
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
