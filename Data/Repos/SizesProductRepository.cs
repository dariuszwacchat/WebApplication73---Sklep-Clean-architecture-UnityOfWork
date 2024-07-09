using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.SizesProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class SizesProductRepository : ISizesProductRepository
    {
        private readonly ApplicationDbContext _context;
        public SizesProductRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SizeProduct>> GetAll ()
        {
            return await _context.SizesProduct.ToListAsync();
        }

        public async Task<SizeProduct> Get (string id)
        {
            return await _context.SizesProduct.FirstOrDefaultAsync(f => f.SizeProductId == id);
        }


        public async Task<CreateSizeProductViewModel> Create (CreateSizeProductViewModel model)
        {
            if (model != null)
            {
                try
                {
                    SizeProduct sizeProduct = new SizeProduct ()
                    {
                        SizeProductId = Guid.NewGuid ().ToString (),
                        Name = model.Name,
                        ProductId = model.ProductId
                    };
                    _context.SizesProduct.Add(sizeProduct);
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



        public async Task<EditSizeProductViewModel> Update (EditSizeProductViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var sizeProduct = await _context.SizesProduct.FirstOrDefaultAsync (f=> f.SizeProductId == model.SizeProductId);
                    if (sizeProduct != null)
                    {
                        sizeProduct.Name = model.Name;
                        sizeProduct.ProductId = model.ProductId;

                        _context.Entry(sizeProduct).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "SizeProduct is null.";
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
                var sizeProduct = await _context.SizesProduct.FirstOrDefaultAsync (f=>f.SizeProductId == id);
                if (sizeProduct != null)
                {
                    _context.SizesProduct.Remove(sizeProduct);
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
