using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Colors
{
    public class ColorsViewModel : BaseViewModel <Color>
    {
        public List<Color> Colors { get; set; }
    }
}
