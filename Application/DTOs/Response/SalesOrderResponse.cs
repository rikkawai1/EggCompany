using System;
using System.Collections.Generic;

namespace Application.DTOs.Response
{
    public class SalesOrderResponse
    {
        public Guid id { get; set; }
        public string order_code { get; set; }
        public Guid customer_id { get; set; }
        public string customer_name { get; set; }
        public DateTime order_date { get; set; }
        public string status { get; set; }
        public List<OrderItemResponse> items { get; set; } = new List<OrderItemResponse>();
    }

    public class OrderItemResponse
    {
        public Guid id { get; set; }
        public Guid incubator_id { get; set; }
        public string serial_number { get; set; }
        public string model_name { get; set; }
    }
}
