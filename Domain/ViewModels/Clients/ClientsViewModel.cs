using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Clients
{
    public class ClientsViewModel : BaseViewModel <Client>
    {
        public List<Client> Clients { get; set; }
    }
}
