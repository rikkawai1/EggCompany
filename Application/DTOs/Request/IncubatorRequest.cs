using System;

namespace Application.DTOs.Request
{
    public class IncubatorRequest
    {
        public string serial_number { get; set; }
        public string qr_code { get; set; }
        public Guid model_id { get; set; }
        public Guid? customer_id { get; set; }
        public string status { get; set; }
    }
}
