using System;
using System.ComponentModel.DataAnnotations;

namespace TicketTrackingAPI.Models
{
    // Define the TicketReply class
    // to represent a reply associated with a ticket in the ticket tracking system
    public class TicketReply
    {
        [Key]
        public int ReplyId { get; set; }
        public long TId { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }       
    }
}