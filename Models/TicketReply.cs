using System;
using System.ComponentModel.DataAnnotations;

namespace TicketTrackingAPI.Models
{
    public class TicketReply
    {
        [Key]
        public int ReplyId { get; set; }
        public long TId { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }       
    }
}