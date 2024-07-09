using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Marki
{
    public class MarkiViewModel : BaseViewModel <Marka>
    {
        public List<Marka> Marki { get; set; }
    }
}
