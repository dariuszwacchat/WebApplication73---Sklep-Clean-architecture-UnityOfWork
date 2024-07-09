using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Newsletters
{
    public class EditNewsletterViewModel : CreateEditNewsletterViewModel
    {
        public string NewsletterId { get; set; }
    }
}
