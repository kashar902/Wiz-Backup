namespace UserAssociates.Business.Viewmodels
{
    public class VisitTypeViewModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SaleInvoicePrefix { get; set; }
        public string? RefundInvoicePrefix { get; set; }
        public bool BlockVisitType { get; set; }
    }
}
