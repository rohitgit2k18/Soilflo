using System;
using System.Collections.Generic;
using System.Text;

namespace Notifit.Services.Models.ResponseModels
{
   public class UserRegistrationResponse
    {
        public LoginResultResponse Response { get; set; }
    }
    public class LoginResultResponse
    {
        public int UserId { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
