using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Orders
{
    public class EditOrderViewModel : CreateEditOrderViewModel
    {
        public string UserName { get; set; }

    }
}
