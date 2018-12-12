using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFlo.Services.Models.RequestModels
{
    public class CreateDriverEmailRequest
    {
        public string cellphone { get; set; }
        public string email { get; set; }
    }
}
