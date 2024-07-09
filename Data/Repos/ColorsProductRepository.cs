using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.ColorsProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ColorsProductRepository : IColorsProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ColorsProductRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ColorProduct>> GetAll ()
        {
            return await _context.ColorsProduct.ToListAsync();
        }

        public async Task<ColorProduct> Get (string id)
        {
            return await _context.ColorsProduct.FirstOrDefaultAsync(f => f.ColorProductId == id);
        }

        public async Task<CreateColorProductViewModel> Create (CreateColorProductViewModel model)
        {
            if (model != null)
            {
                try
                {
                    ColorProduct colorProduct = new ColorProduct ()
                    {
                        ColorProductId = Guid.NewGuid ().ToString (),
                        Name = model.Name,
                        ProductId = model.ProductId
                    };
                    _context.ColorsProduct.Add(colorProduct);
                    await _context.SaveChangesAsync();
                    model.Success = true;
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


        public async Task<EditColorProductViewModel> Update (EditColorProductViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.ColorsProduct.FirstOrDefaultAsync(f => f.Name == model.Name)) == null)
                    {
                        var colorProduct = await _context.ColorsProduct.FirstOrDefaultAsync (f=> f.ColorProductId == model.ColorProductId);
                        if (colorProduct != null)
                        {
                            colorProduct.Name = model.Name;
                            colorProduct.ProductId = model.ProductId;

                            _context.Entry(colorProduct).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
                        }
                        else
                        {
                            model.Result = "ColorProduct is null.";
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
                var colorProduct = await _context.ColorsProduct.FirstOrDefaultAsync (f=>f.ColorProductId == id);
                if (colorProduct != null)
                {
                    _context.ColorsProduct.Remove(colorProduct);
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
