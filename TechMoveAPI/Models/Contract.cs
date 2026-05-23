using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechMoveAPI.Models
{
    public class Contract
    {
        [Required] public int ContractId { get; set; }
        [Required] public DateOnly StartDate { get; set; }
        [Required] public DateOnly EndDate { get; set; }

        public string? Status { get; set; } = string.Empty;

        [Required] public string ServiceLevel { get; set; } = string.Empty;
        public string? FilePath { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

    }
}
