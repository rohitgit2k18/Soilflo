using System;
using System.Collections.Generic;
using System.Text;

namespace Notifit.Services.Models.RequestModels
{
   public class ResetPasswordRequest
    {
        public int OTP { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
