using System;
namespace MobileFlo.Services.Models.RequestModels
{
    public class SetPositionRequestModel
    {
        public string scancode { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
