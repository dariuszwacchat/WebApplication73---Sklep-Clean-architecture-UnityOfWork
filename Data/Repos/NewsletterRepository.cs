using Data.Repos.Abs;
using Domain.Models;
using Domain.ViewModels.Newsletters;
using Domain.ViewModels.Sizes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsletterRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Newsletter>> GetAll ()
        {
            return await _context.Newsletters.ToListAsync();
        }

        public async Task<Newsletter> Get (string id)
        {
            return await _context.Newsletters.FirstOrDefaultAsync(f => f.NewsletterId == id);
        }


        public async Task<CreateNewsletterViewModel> Create (CreateNewsletterViewModel model)
        {
            if (model != null)
            {
                try
                {
                    if ((await _context.Newsletters.FirstOrDefaultAsync(f => f.Email == model.Email)) == null)
                    {
                        Newsletter newsletter = new Newsletter ()
                        {
                            NewsletterId = Guid.NewGuid ().ToString (),
                            Email = model.Email
                        };
                        _context.Newsletters.Add(newsletter);
                        await _context.SaveChangesAsync();
                        model.Success = true;
                    }
                    else
                    {
                        model.Result = "Wskazana użytkownik jest już dodany do newslettera.";
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
                var newsletter = await _context.Newsletters.FirstOrDefaultAsync (f=>f.NewsletterId == id);
                if (newsletter != null)
                {
                    _context.Newsletters.Remove(newsletter);
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
