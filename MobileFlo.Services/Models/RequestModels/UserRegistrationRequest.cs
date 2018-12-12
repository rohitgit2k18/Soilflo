using System;
using System.Collections.Generic;
using System.Text;

namespace Notifit.Services.Models.RequestModels
{
   public class UserRegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int CountryId { get; set; }
    }
}
