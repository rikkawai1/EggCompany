using System;

namespace Application.DTOs.Response
{
    public class WarrantyResponse
    {
        public Guid id { get; set; }
        public Guid incubator_id { get; set; }
        public string incubator_serial { get; set; }
        public string qr_code { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string status { get; set; }
        public string customer_name { get; set; }
    }
}
