using System;
using System.Collections.Generic;

namespace MobileFlo.Services.Models.ResponseModels
{
    public class InvoiceListResponseModel
    {
        public string status { get; set; }
        public List<GetInvoices> GetInvoicesResult { get; set; }
    }
    public class GetInvoices
    {
        public string Date { get; set; }
        public string NumberofLoads { get; set; }
    }
}
