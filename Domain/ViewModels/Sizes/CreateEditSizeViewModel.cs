using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Sizes
{
    public class CreateEditSizeViewModel
    {
        [Required (ErrorMessage = "*")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Wartość pola musi być liczbą całkowitą lub zmiennoprzecinkową.")]
        public string Name { get; set; }


        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
