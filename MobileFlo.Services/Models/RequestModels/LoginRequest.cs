using System;
using System.Collections.Generic;
using System.Text;

namespace Notifit.Services.Models.RequestModels
{
    public class LoginRequest : BaseRequestModel
    {
        public LoginRequest()
        {
            //string Username, Password, Grant_type;
            //Username = userName;
            //Password = password;
            //Grant_type = grant_type;
        }
        public string _username;
        public string Email
        {

            get
            {
                return _username;
            }
            set
            {
                _username = value; OnPropertyChanged();
            }
        }
        public string _paswword;
        public string Password
        {
            get
            {
                return _paswword;
            }
            set
            {
                _paswword = value; OnPropertyChanged();
            }
        }
        public string grant_type = "password";
    }
}
