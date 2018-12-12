using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFlo.Services.Models.RequestModels
{
    public class CreateDriverNameRequest
    {
        public string cellphone { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
