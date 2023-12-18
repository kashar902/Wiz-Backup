using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities
{
    [Table("Companies")]
    public class Company : BaseEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? Masking { get; set; }
        public string? StartDate { get; set; }
        public bool Active { get; set; }
        public int GroupOfCompanyId { get; set; }
        public GroupOfCompany? GroupOfCompanies { get; set; }
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }
    }
}
