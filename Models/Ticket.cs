using System;

namespace TicketTrackingAPI.Models
{
    // Define the Ticket class to represent a ticket in the ticket tracking system
    public class Ticket
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int TicketTypeId { get; set; }
        public int InstalledEnvironmentId {get; set;}
        public DateTime Date { get; set; }   
        public DateTime LastModified { get; set; }   
    }
}
