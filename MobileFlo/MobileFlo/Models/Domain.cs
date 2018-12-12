using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFlo.Models
{
  public static class Domain
    {
        public static string Url
        {
          
            get
            {
                 return "http://api.staging.soilflo.com/hauler/";
               
            }
        }


        public static string GetCountryApiConstant
        {
            get
            {
                return "https://restcountries.eu/rest/v2/all";
            }
        }
        public static string CreateDriverApiConstant
        {
            get
            {
                return "CreateDriver";
            }
        }

        public static string GetInnerVoiceApiConstant
        {
            get
            {
                return "GetDailyDeliveries";
            }
        }

        public static string GetInvoiceApiConstant
        {
            get
            {
                return "GetInvoices";
            }
        }
        public static string SetStatusApiConstant
        {
            get
            {
                return "SetStatus";
            }
        }

        public static string SetCurrentPositionApiConstant
        {
            get
            {
                return "SetCurrentPosition";
            }
        }

        public static string CodeValidateApiConstant
        {
            get
            {
                return "ValidateCode";
            }
        }

        public static string UpdateDriverEmailApiConstant
        {
            get
            {
                return "UpdateDriverEmail";
            }
        }
        
        public static string UpdateDriverNameApiConstant
        {
            get
            {
                return "UpdateDriverName";
            }
        }

        public static string ResendCodeApiConstant
        {
            get
            {
                return "ResendCode";
            }
        }

        public static string StartHauling
        {
            get
            {
                return "GetProject";
            }
        }


        public static string CreateDriverEmailApiConstant
        {
            get
            {
                return "UpdateDriverEmail";
            }
        }
        //-----------------------------Non Driver-------------------------------

    }
}
