namespace UserAssociates.Business.Viewmodels
{
    public class CityTaxViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
