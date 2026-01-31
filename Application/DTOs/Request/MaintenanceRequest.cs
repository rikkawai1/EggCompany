using System;

namespace Application.DTOs.Request
{
    public class MaintenanceTicketRequest
    {
        public Guid incubator_id { get; set; }
        public Guid? technician_id { get; set; }
        public string issue_description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
    }

    public class MaintenanceLogRequest
    {
        public Guid ticket_id { get; set; }
        public string action_taken { get; set; }
        public string notes { get; set; }
    }
}
