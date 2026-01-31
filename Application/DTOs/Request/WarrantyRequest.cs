using System;

namespace Application.DTOs.Request
{
    public class WarrantyRequest
    {
        public Guid incubator_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string status { get; set; }
    }
}
