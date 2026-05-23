using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMoveAPI.Data;
using TechMoveAPI.Models;

namespace TechMoveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ServiceRequestController : Controller
    {
        private readonly DataContext _context;
        public ServiceRequestController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequest>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetAllServiceRequests()
        {
            var serviceRequests = await _context.ServiceRequests.ToListAsync();
            return Ok(serviceRequests);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllServiceRequests), new { id = serviceRequest.ServiceRequestId }, serviceRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceRequest>> EditServiceRequest(int id, ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Update(serviceRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllServiceRequests), new { id = serviceRequest.ServiceRequestId }, serviceRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceRequest>> DeleteServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllServiceRequests), new { id = serviceRequest.ServiceRequestId }, serviceRequest);
        }

    }
}


