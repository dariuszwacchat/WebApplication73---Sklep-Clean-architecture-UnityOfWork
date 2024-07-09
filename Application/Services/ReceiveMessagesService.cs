using Data;
using Domain.Models;
using Domain.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReceiveMessagesService
    {
        public readonly ApplicationDbContext _context;

        public ReceiveMessagesService (ApplicationDbContext context)
        {
            _context = context;
        }
          

        public async Task<List<ReceiveMessage>> GetAll ()
        {
            return await _context.ReceiveMessages.ToListAsync();
        }

        public async Task<List<ReceiveMessage>> GetAll (string userId)
        {
            return await _context.ReceiveMessages.Where (w=> w.FromUserId == userId).ToListAsync ();
        }

        public async Task<ReceiveMessage> Get (string id)
        {
            ReceiveMessage receiveMessage = await _context.ReceiveMessages.FirstOrDefaultAsync(f=>f.ReceiveMessageId == id);
            receiveMessage.MessageStatus = MessageStatus.Odebrana;
            receiveMessage.DataOdebrania = DateTime.Now;
            _context.Entry(receiveMessage).State = EntityState.Modified;

            SendMessage sendMessage = _context.SendMessages.FirstOrDefault(f=>f.SendMessageId == receiveMessage.SendMessageId); 
            sendMessage.MessageStatus = MessageStatus.Odebrana;
            _context.Entry(receiveMessage).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return receiveMessage;
        }


        /*
                public async Task<CreateRoleViewModel> Create (CreateRoleViewModel model)
                {
                    if (model != null)
                    {
                        try
                        {
                            if ((await _context.Roles.FirstOrDefaultAsync(f => f.Name == model.Name)) == null)
                            {
                                ApplicationRole role = new ApplicationRole ()
                                {
                                    Id = Guid.NewGuid ().ToString (),
                                    Name = model.Name,
                                    NormalizedName = model.Name,
                                    ConcurrencyStamp = Guid.NewGuid().ToString()
                                };

                                _context.Roles.Add(role);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                model.IsExists = true;
                                model.Result = "Podana nazwa roli już istnieje.";
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
        */
        public async Task Delete (string id)
        {
            try
            {
                var model = await _context.ReceiveMessages.FirstOrDefaultAsync (f=>f.ReceiveMessageId == id);
                if (model != null)
                {
                    _context.ReceiveMessages.Remove(model);
                    await _context.SaveChangesAsync();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }


        /* public async Task<EditRoleViewModel> Update (EditRoleViewModel model)
         {
             if (model != null)
             {
                 try
                 {
                     ReceiveMessage receiveMessage = _context.ReceiveMessages.FirstOrDefault(f=>f.ReceiveMessageId == id);

                     if (receiveMessage == null)
                     {
                         return View("NotFound")();
                     }
                     try
                     {
                         _context.Update(receiveMessage);
                         await _context.SaveChangesAsync();
                     }
                     catch (Exception)
                     {

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
 */



    }
}
