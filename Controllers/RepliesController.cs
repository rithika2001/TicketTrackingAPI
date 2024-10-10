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
    public class RepliesController : ControllerBase
    {
        private readonly TicketReplyContext _context;

        public RepliesController(TicketReplyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReply>>> GetReplies()
        {
            return await _context.TicketReplies.ToListAsync();
        }

        [HttpGet("{ReplyId}")]
        public async Task<ActionResult<TicketReply>> GetTicketReplies(int ReplyId)
        {
            var ticketReplies = await _context.TicketReplies.FindAsync(ReplyId);
            if (ticketReplies == null)
            {
                return NotFound();
            }
            return ticketReplies;
        }

        // New POST method
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
