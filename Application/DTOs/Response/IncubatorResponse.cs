using System;

namespace Application.DTOs.Response
{
    public class IncubatorResponse
    {
        public Guid id { get; set; }
        public string serial_number { get; set; }
        public string qr_code { get; set; }
        public Guid model_id { get; set; }
        public string model_name { get; set; }
        public Guid? customer_id { get; set; }
        public string customer_name { get; set; }
        public DateTime? activated_at { get; set; }
        public string status { get; set; }
        
        // IoT Data (optional, can be populated from sensors)
        public decimal? temperature { get; set; }
        public decimal? humidity { get; set; }
    }
}
