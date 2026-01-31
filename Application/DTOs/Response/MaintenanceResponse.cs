using System;
using System.Collections.Generic;

namespace Application.DTOs.Response
{
    public class MaintenanceTicketResponse
    {
        public Guid id { get; set; }
        public Guid incubator_id { get; set; }
        public string incubator_serial { get; set; }
        public Guid? technician_id { get; set; }
        public string technician_name { get; set; }
        public string issue_description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public DateTime? created_at { get; set; }
        public List<MaintenanceLogResponse> logs { get; set; } = new List<MaintenanceLogResponse>();
    }

    public class MaintenanceLogResponse
    {
        public Guid id { get; set; }
        public Guid ticket_id { get; set; }
        public string action_taken { get; set; }
        public string notes { get; set; }
        public DateTime? created_at { get; set; }
    }
}
