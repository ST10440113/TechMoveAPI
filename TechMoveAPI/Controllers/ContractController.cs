using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMoveAPI.Data;
using TechMoveAPI.Models;

namespace TechMoveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ContractController : Controller
    {
        private readonly DataContext _context;
        public ContractController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contract>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAllContracts()
        {
            var contracts = await _context.Contracts.ToListAsync();
            return Ok(contracts);
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> CreateContract(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllContracts), new { id = contract.ContractId }, contract);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contract>> EditContract(int id, Contract contract)
        {
            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllContracts), new { id = contract.ContractId }, contract);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contract>> DeleteContract(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllContracts), new { id = contract.ContractId }, contract);
        }

    }
}

