using System;
using System.Collections.Generic;
using System.Text;

namespace Notifit.Services.Models.ResponseModels
{
   public class LoginResponse
    {
        public LoggedinResponse Response { get; set; }
    }

    public class LoggedinResponse
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string TokenCode { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }    
}
