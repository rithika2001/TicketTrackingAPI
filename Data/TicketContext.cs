using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Models; // Make sure to include the models

namespace TicketTrackingAPI.Data
{
    // Define the TicketContext class,
    // which is the Entity Framework Core database context for the application
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maps the Ticket entity to the "Ticket" table in the "Support" schema
            modelBuilder.Entity<Ticket>().ToTable("Ticket", "Support");
        }
    }
}
