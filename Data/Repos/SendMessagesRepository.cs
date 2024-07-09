using Data.Repos.Abs;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.SendMessages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Data.Repos
{
    public class SendMessagesRepository : ISendMessagesRepository
    {
        private readonly ApplicationDbContext _context;

        public SendMessagesRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SendMessage>> GetAll ()
        {
            return await _context.SendMessages
                .Include(i => i.FromUser)
                .Include(i => i.ToUser)
                .ToListAsync ();
        }

        public async Task<List<SendMessage>> GetAll (string userName)
        {
            return (await _context.Users 
                .Include(i => i.SendMessages)
                    .ThenInclude(t => t.ToUser)
                .FirstOrDefaultAsync (f=> f.UserName == userName))
                .SendMessages; 
        }

        public async Task<SendMessage> Get (string sendMessageId)
        {
            return await _context.SendMessages 
                .Include(i => i.FromUser)
                .Include(i => i.ToUser)
                .FirstOrDefaultAsync(f => f.SendMessageId == sendMessageId);
        }

        public async Task<CreateSendMessageViewModel> Create (CreateSendMessageViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync (f=> f.UserName == model.UserName);
                    if (user != null)
                    {
                        SendMessage sendMessage = new SendMessage ()
                        {
                            SendMessageId = Guid.NewGuid ().ToString (),
                            Title = model.Title,
                            Description = model.Description,
                            FromUserId = user.Id,
                            ToUserId = model.ToUserId,
                            MessageStatus = MessageStatus.Nieodebrana,
                            DataNadania = DateTime.Now,
                        };
                        _context.SendMessages.Add(sendMessage);
                        await _context.SaveChangesAsync();


                        ReceiveMessage receiveMessage = new ReceiveMessage ()
                        {
                            ReceiveMessageId = Guid.NewGuid ().ToString (),
                            Title = sendMessage.Title,
                            Description = sendMessage.Description,
                            FromUserId = user.Id,
                            ToUserId = model.ToUserId,
                            DataNadania = DateTime.Now,
                            MessageStatus = MessageStatus.Nieodebrana,
                            SendMessageId = sendMessage.SendMessageId
                        };
                        _context.ReceiveMessages.Add(receiveMessage);
                        await _context.SaveChangesAsync();

                        model.Result = "Wiadomość wysłana.";
                    }
                    else
                    {
                        model.Result = "User is null.";
                    }
                }
                catch (Exception ex)
                {
                    model.Result = "Catch exception.";
                }
            }
            else
            {
                model.Result = "Modes is null.";
            }
            return model;
        }

        public async Task <bool> Delete (string id)
        {
            bool result = false;
            try
            {
                var model = await _context.SendMessages.FirstOrDefaultAsync (f=>f.SendMessageId == id);
                if (model != null)
                {
                    _context.SendMessages.Remove(model);
                    await _context.SaveChangesAsync();

                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        /*
                public async Task<EditUserViewModel> Update (EditUserViewModel model)
                {
                    if (model != null)
                    {
                        try
                        {
                            var user = _context.Users.FirstOrDefault (f=> f.Id == model.UserId);
                            if (user != null)
                            {
                                user.Imie = model.Imie;
                                user.Nazwisko = model.Nazwisko;
                                user.Ulica = model.Ulica;
                                user.NumerUlicy = model.NumerUlicy;
                                user.Miejscowosc = model.Miejscowosc;
                                user.Kraj = model.Kraj;
                                user.KodPocztowy = model.KodPocztowy;

                                _context.Entry(user).State = EntityState.Modified;
                                await _context.SaveChangesAsync();



                            }
                        }
                        catch (Exception ex)
                        {
                            model.Result = "Błąd podczas edycji danych.";
                        }
                    }
                    else
                    {
                    }
                    return model;
                }
        */



        public async Task<List<ApplicationUser>> GetUsers ()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<ApplicationUser> ToUser (string sendMessageId)
        {
            return (await _context.SendMessages
                .Include (i=> i.ToUser)
                .FirstOrDefaultAsync (f=> f.SendMessageId == sendMessageId))
                        .ToUser;
        }

    }
}
