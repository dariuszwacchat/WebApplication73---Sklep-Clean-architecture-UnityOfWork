using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Payments
{
    public class PaymentsViewModel
    {
        public string OrderId { get; set; }

        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string SposobPlatnosci { get; set; }


        [Required(ErrorMessage = "Jedna z opcji musi być wybrana")]
        public string SposobWysylki { get; set; }
    }
}
