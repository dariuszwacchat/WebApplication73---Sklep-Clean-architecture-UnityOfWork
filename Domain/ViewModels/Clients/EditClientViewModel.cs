using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Clients
{
    public class EditClientViewModel : CreateEditClientViewModel
    {
        public string ClientId { get; set; }

        public List <PhotoClient> PhotosClient { get; set; }
    }
}
