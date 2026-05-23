using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechMoveAPI.Models
{
    public class ServiceRequest
    {
        [Required] public int ServiceRequestId { get; set; }
        [Required] public double Cost { get; set; }
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public string Status { get; set; } = string.Empty;

        [ForeignKey("ContractId")]
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
        [Required] public double ZarAmount { get; set; }
    }
}
