using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Models; // Make sure to include the models

namespace TicketTrackingAPI.Data
{
    // Define the TicketReplyContext class,
    // which serves as the database context for TicketReply entities
    public class TicketReplyContext : DbContext
    {
        public TicketReplyContext(DbContextOptions<TicketReplyContext> options) : base(options) { }

        public DbSet<TicketReply> TicketReplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // TicketReply entity to be mapped to the "TicketReply" table in the "Support" schema
            modelBuilder.Entity<TicketReply>().ToTable("TicketReply", "Support");
        }
    }
}
