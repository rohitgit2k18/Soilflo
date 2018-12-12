using System;
namespace MobileFlo.Services.Models.RequestModels
{
    public class SetStatusRequest
    {
        public string scancode { get; set; }
        public string status { get; set; }
    }
}
