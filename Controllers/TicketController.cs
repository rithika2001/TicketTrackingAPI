using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Data; // Ensure this points to the Data namespace
using TicketTrackingAPI.Models; // Ensure this points to the Models namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace TicketTrackingAPI.Controllers
{
    // Define the TicketsController class, which is a controller for handling
    // HTTP requests related to tickets
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context)
        {
            _context = context;
        }

        // GET ALL
        // method to handle GET requests and return a list of all tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET(1)
        // method to handle GET requests for a specific ticket based on its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(long id)
        {
            // find a ticket by its ID
            var ticket = await _context.Tickets.FindAsync(id);
            // If the ticket is not found, return a 404 Not Found response
            if (ticket == null)
            {
                return NotFound();
            }
            // Return the found ticket
            return ticket;
        }

        [HttpPost]
        // POST method
        // Action method to handle POST requests for creating a new ticket
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            // Adding the new ticket to the Tickets table
            _context.Tickets.Add(ticket);

            // Save changes asynchronously to the database
            await _context.SaveChangesAsync();

            // Return the newly created ticket along with a 201 Created response
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }
    }
}
