using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Sizes
{
    public class SizesViewModel : BaseViewModel <Size>
    {
        public List<Size> Sizes { get; set; }
    }
}
