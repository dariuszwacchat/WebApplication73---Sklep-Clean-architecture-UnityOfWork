using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Orders
{
    public class OrderFormularzViewModel
    {
        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string RodzajTransakcji { get; set; }


        public string Result { get; set; }
    }
}
