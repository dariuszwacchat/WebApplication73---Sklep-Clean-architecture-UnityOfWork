using Domain.Models;
using Domain.ViewModels.SendMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Data.Repos.Abs
{
    public interface ISendMessagesRepository
    {
        Task <List<SendMessage>> GetAll ();
        Task <List<SendMessage>> GetAll (string userName);
        Task <SendMessage> Get (string sendMessageId);
        Task <CreateSendMessageViewModel> Create (CreateSendMessageViewModel model);
        Task<List<ApplicationUser>> GetUsers ();
        Task<ApplicationUser> ToUser (string sendMessageId);
        Task<bool> Delete (string id);
    }
}
