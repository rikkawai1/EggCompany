using System;
using System.Collections.Generic;

namespace Application.DTOs.Request
{
    public class UserCreateRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<int> role_ids { get; set; }
    }

    public class UserUpdateRequest
    {
        public Guid id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
    }
}
