using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Koszyk
{
    public class KoszykViewModel
    {
        public string KoszykItemId { get; set; }
        public int Ilosc { get; set; }
        public List<KoszykItem> KoszykItems { get; set; }

    }
}
