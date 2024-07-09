using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Domain.ViewModels.Users
{
    public class UsersViewModel : BaseViewModel <ApplicationUser>
    {
        public List <ApplicationUser> Users { get; set; }
    }
}
