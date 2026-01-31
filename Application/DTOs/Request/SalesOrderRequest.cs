using System;
using System.Collections.Generic;

namespace Application.DTOs.Request
{
    public class SalesOrderRequest
    {
        public string order_code { get; set; }
        public Guid customer_id { get; set; }
        public DateTime order_date { get; set; }
        public string status { get; set; }
        public List<Guid> incubator_ids { get; set; }
    }
}
