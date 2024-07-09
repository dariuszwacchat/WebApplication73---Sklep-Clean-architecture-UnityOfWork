using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Sizes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class SizesRepository : ISizesRepository
    {
        private readonly ApplicationDbContext _context;
        public SizesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Size>> GetAll ()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> Get (string id)
        {
            return await _context.Sizes.FirstOrDefaultAsync(f => f.SizeId == id);
        }


        public async Task<CreateSizeViewModel> Create (CreateSizeViewModel model)
        {
            if (model != null)
            {
                try
                {
                    // Zapobiega dodaniu drugi raz tej samej nazwy
                    if ((await _context.Sizes.FirstOrDefaultAsync(f => f.Name == model.Name)) == null)
                    {
                        Size size = new Size ()
                        {
                            SizeId = Guid.NewGuid ().ToString (),
                            Name = model.Name
                        };
                        _context.Sizes.Add(size);
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

         

        public async Task<EditSizeViewModel> Update (EditSizeViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Sizes.FirstOrDefaultAsync(f => f.Name == model.Name && f.SizeId != model.SizeId)) == null)
                    {
                        var size = await _context.Sizes.FirstOrDefaultAsync (f=> f.SizeId == model.SizeId);
                        if (size != null)
                        {
                            size.Name = model.Name; 

                            _context.Entry(size).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "Size is null.";
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
                var size = await _context.Sizes.FirstOrDefaultAsync (f=>f.SizeId == id);
                if (size != null)
                {
                    _context.Sizes.Remove(size);
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
