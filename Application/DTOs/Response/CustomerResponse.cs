using System;

namespace Application.DTOs.Response
{
    public class CustomerResponse
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime? created_at { get; set; }
    }
}
