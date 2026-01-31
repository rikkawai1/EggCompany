using System;
using System.Collections.Generic;

namespace Application.DTOs.Response
{
    public class UserResponse
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public DateTime? created_at { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}
