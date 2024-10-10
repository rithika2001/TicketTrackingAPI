 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Data; // Ensure this points to your Data namespace
using TicketTrackingAPI.Models; // Ensure this points to your Models namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(long id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            // Add the new ticket to the Tickets table
            _context.Tickets.Add(ticket);

            // Save changes asynchronously to the database
            await _context.SaveChangesAsync();

            // Return the newly created ticket along with a 201 Created response
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }
    }
}
