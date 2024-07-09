using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Domain.ViewModels.SendMessages
{
    public class DetailsSendMessageViewModel
    {
        public ApplicationUser ToUser { get; set; }
        public SendMessage SendMessage { get; set; }
    }
}
