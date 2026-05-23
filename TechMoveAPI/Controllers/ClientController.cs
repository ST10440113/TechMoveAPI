using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMoveAPI.Data;
using TechMoveAPI.Models;

namespace TechMoveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly DataContext _context;
        public ClientController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            var users = await _context.Clients.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllClients), new { id = client.ClientId }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> EditClient(int id, Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllClients), new { id = client.ClientId }, client);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllClients), new { id = client.ClientId }, client);
        }

    }
}

