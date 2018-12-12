using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFlo.Services.Models.ResponseModels
{
    public class StarHaulingResponseModel
    {
        public string status { get; set; }
        public string ProjectName { get; set; }
        public string LicensePlate { get; set; }
        public string WaitTime { get; set; }
        public string message { get; set; }
    }
}
