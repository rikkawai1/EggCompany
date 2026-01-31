using System;

namespace Application.DTOs.Response
{
    public class IncubatorModelResponse
    {
        public Guid id { get; set; }
        public string model_code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? created_at { get; set; }
    }
}
