using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Domain.ViewModels.ReceiveMessages
{
    public class DetailsReceiveMessageViewModel
    {
        public ApplicationUser FromUser { get; set; }
        public ReceiveMessage ReceiveMessage { get; set; }
    }
}
