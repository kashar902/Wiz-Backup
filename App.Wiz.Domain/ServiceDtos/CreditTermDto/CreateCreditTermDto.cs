using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CreditTermDto;

public class CreateCreditTermDto : CreateDtoBaseEntities
{
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    [Required]
    public int Term { get; set; }
    [Required]
    public char TermUnit { get; set; }
}
