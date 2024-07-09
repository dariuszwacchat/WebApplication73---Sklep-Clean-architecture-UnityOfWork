using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Orders
{
    public class OrderConfirmationViewModel
    {
        public Client Client { get; set; }
        public Order Order { get; set; }
        public List<KoszykItem> KoszykItems { get; set; }
    }
}
