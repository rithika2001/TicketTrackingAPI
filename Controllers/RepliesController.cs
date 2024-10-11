using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketTrackingAPI.Data; // Ensure this points to your Data namespace
using TicketTrackingAPI.Models; // Ensure this points to your Models namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketTrackingAPI.Controllers
{ 
    // Defines the RepliesController class, which is a controller for handling
    // HTTP requests related to ticket replies
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly TicketReplyContext _context;

        public RepliesController(TicketReplyContext context)
        {
            _context = context;
        }
        // GET ALL
        // method to handle GET requests and return a list of all ticket replies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReply>>> GetReplies()
        {
            return await _context.TicketReplies.ToListAsync();
        }

        // GET (1)
        // method to handle GET requests for a specific ticket reply based on its ID
        [HttpGet("{ReplyId}")]
        public async Task<ActionResult<TicketReply>> GetTicketReplies(int ReplyId)
        {
            // find a ticket reply by its ID
            var ticketReplies = await _context.TicketReplies.FindAsync(ReplyId);
            
            // If the ticket reply is not found, return a 404 Not Found response
            if (ticketReplies == null)
            {
                return NotFound();
            }
            return ticketReplies;
        }

        // POST method
        // method to handle POST requests for creating a new ticket reply
        [HttpPost]
        public async Task<ActionResult<TicketReply>> PostTicketReply(TicketReply ticketReply)
        {
            // Add the new ticket reply to the context
            _context.TicketReplies.Add(ticketReply);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return a response with the created ticket reply
            return CreatedAtAction(nameof(GetTicketReplies), new { ReplyId = ticketReply.ReplyId }, ticketReply);
        }
    }
}
