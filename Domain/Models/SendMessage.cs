using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SendMessage
    {
        [Key]
        public string SendMessageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DataNadania { get; set; }
        public MessageStatus MessageStatus { get; set; }

        public string FromUserId { get; set; }
        public ApplicationUser FromUser { get; set; }

         
        public string ToUserId { get; set; }
        //[NotMapped]
        public ApplicationUser ToUser { get; set; }
    }
}
