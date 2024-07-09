﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Abs
{
    public interface IReceiveMessagesService
    {
        Task <List<ReceiveMessage>> GetAll ();
        Task <List<ReceiveMessage>> GetAll (string userName);
        Task <ReceiveMessage> Get (string id);
        Task <ApplicationUser> FromUser (string receiveMessageId);
        Task Delete (string id);
    }
}
