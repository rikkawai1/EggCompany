using System;

namespace Application.DTOs.Request
{
    public class CustomerRequest
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}
