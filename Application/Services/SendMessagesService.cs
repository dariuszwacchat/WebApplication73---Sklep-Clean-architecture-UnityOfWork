using Data;
using Domain.Models;
using Domain.Models.Enum;
using Domain.ViewModels.SendMessages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SendMessagesService
    {
        private readonly ApplicationDbContext _context;

        public SendMessagesService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SendMessage>> GetAll ()
        {
            return await _context.SendMessages.ToListAsync();
        }

        public async Task<List<SendMessage>> GetAll (string userId)
        {
            return await _context.SendMessages.Where (w=> w.FromUserId == userId).ToListAsync ();
        }

        public async Task<SendMessage> Get (string id)
        {
            return await _context.SendMessages.FirstOrDefaultAsync(f => f.SendMessageId == id);
        }

        public async Task<CreateSendMessageViewModel> Create (CreateSendMessageViewModel model)
        {
            if (model != null)
            {
                try
                {  
                    SendMessage sendMessage = new SendMessage ()
                    {
                        SendMessageId = Guid.NewGuid ().ToString (),
                        Title = model.Title,
                        Description = model.Description,
                        FromUserId = model.FromUserId,
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
                        FromUserId = model.FromUserId,  
                        ToUserId = model.ToUserId,
                        DataNadania = DateTime.Now,
                        MessageStatus = MessageStatus.Nieodebrana,
                        SendMessageId = sendMessage.SendMessageId
                    };
                    _context.ReceiveMessages.Add(receiveMessage);
                    await _context.SaveChangesAsync(); 
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
            }
            return model;
        }

        public async Task Delete (string id)
        {
            try
            {
                var model = await _context.SendMessages.FirstOrDefaultAsync (f=>f.SendMessageId == id);
                if (model != null)
                {
                    _context.SendMessages.Remove(model);
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
    }
}
