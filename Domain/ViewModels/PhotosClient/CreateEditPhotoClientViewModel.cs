using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.PhotosClient
{
    public class CreateEditPhotoClientViewModel
    {
        public string PhotoClientId { get; set; }
        public byte[] PhotoData { get; set; }
        public string ClientId { get; set; }



        public bool Success { get; set; }
        public string Result { get; set; }
    }
}
