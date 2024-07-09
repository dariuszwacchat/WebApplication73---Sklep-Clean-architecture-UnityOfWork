using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abs
{
    public interface IEmailSender
    {
        public void Send (string email);
        //public void Send (string email, string title, string description); 
    }
}
