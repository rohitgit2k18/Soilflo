using System;
using System.Collections.Generic;
using MobileFlo.Services.ApiHandler;

namespace MobileFlo.Services.Models.ResponseModels
{
    public class InnerVoiceResponseModel
    {
        public string status { get; set; }
        public List<GetDailyDeliveriesResult> GetDailyDeliveriesResult { get; set; }

    }
    public class GetDailyDeliveriesResult
    {
        public string Project { get; set; }
        public string NumberofTrips { get; set; }
        public string StartTime { get; set; }
    }
}



