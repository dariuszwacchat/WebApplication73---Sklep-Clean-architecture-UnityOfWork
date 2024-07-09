using Domain.Models;
using Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 

namespace Domain.ViewModels.Account
{
    public class UpdateAccountViewModel : RegisterUpdateViewModel
    {
        public string UserName { get; set; } 
    }
}
