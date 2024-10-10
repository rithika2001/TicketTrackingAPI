using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Models; // Make sure to include your models

namespace TicketTrackingAPI.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().ToTable("Ticket", "Support");
        }
    }
}
