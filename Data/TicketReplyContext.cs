using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Models; // Make sure to include your models

namespace TicketTrackingAPI.Data
{
    public class TicketReplyContext : DbContext
    {
        public TicketReplyContext(DbContextOptions<TicketReplyContext> options) : base(options) { }

        public DbSet<TicketReply> TicketReplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketReply>().ToTable("TicketReply", "Support");
        }
    }
}
