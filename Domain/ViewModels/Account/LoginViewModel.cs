using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "*")]
        [DataType(DataType.EmailAddress), MinLength(5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password), MinLength(10)]
        public string Password { get; set; }

        public bool UserIsAdmin { get; set; }
        public bool IsLoggedIn { get; set; }
        public string Result { get; set; }
    }
}
