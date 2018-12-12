using System;
namespace MobileFlo.Services.Models.ResponseModels
{
    public class LoadInfoResponse
    {
        public string status { get; set; }
        public string TicketID { get; set; }
        public string SoilType { get; set; }
        public string SourceSiteName { get; set; }
        public string DisposalSiteName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Province { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Quadrant { get; set; }
        public string message { get; set; }
        public string ProjectName { get; set; }
        public string LicensePlate { get; set; }
    }
}
