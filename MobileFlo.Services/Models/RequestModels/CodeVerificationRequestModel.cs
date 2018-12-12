using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFlo.Services.Models.RequestModels
{
    public class CodeVerificationRequestModel
    {
        public string cellphone { get; set; }
        public string code { get; set; }
    }
}
