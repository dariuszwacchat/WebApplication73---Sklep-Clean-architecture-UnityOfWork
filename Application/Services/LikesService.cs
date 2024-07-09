using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LikesService
    {
        /*private readonly ApplicationDbContext _context;
        public LikesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Color>> GetAll ()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> Get (string id)
        {
            return await _context.Colors.FirstOrDefaultAsync(f => f.ColorId == id);
        }

        public async Task<CreateColorViewModel> Create (CreateColorViewModel model)
        {
            if (model != null)
            {
                try
                {
                    Color color = new Color ()
                    {
                        ColorId = Guid.NewGuid ().ToString (),
                        Name = model.Name
                    };
                    _context.Colors.Add(color);
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

        public async Task<bool> Delete (string id)
        {
            bool deleteResult = false;
            try
            {
                var color = await _context.Colors.FirstOrDefaultAsync (f=>f.ColorId == id);
                if (color != null)
                {
                    _context.Colors.Remove(color);
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

        public async Task<EditColorViewModel> Update (EditColorViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Colors.FirstOrDefaultAsync(f => f.Name == model.Name)) == null)
                    {
                        var color = await _context.Colors.FirstOrDefaultAsync (f=> f.ColorId == model.ColorId);
                        if (color != null)
                        {
                            color.Name = model.Name;

                            _context.Entry(color).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            model.Success = true;
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
        }*/
    }
}
