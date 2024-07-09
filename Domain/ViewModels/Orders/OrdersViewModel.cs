using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Orders
{
    public class OrdersViewModel : BaseViewModel <Order>
    {
        public List <Order> Orders { get; set; }
    }
}
