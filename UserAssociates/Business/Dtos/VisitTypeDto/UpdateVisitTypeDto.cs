using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.VisitTypeDto
{
    public class UpdateVisitTypeDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? SaleInvoicePrefix { get; set; }

        [Required]
        public string? RefundInvoicePrefix { get; set; }

        [Required]
        public bool BlockVisitType { get; set; }
    }
}
