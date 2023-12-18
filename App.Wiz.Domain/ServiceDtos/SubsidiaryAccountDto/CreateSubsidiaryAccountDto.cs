using App.Wiz.Common.BaseEntity;
using App.Wiz.Domain.ServiceDtos.AccAssignBranchDto;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.SubsidiaryAccountDto;

public class CreateSubsidiaryAccountDto : CreateDtoBaseEntities
{
    public CreateSubsidiaryAccountDto()
    {
        CompaniesData = new List<CompaniesData>();
        AccBudget = new List<AccBudgetDto>();
    }
    public string Title { get; set; }
    [Required]
    public string ControlAccountId { get; set; }
    public int CurrencyId { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public decimal? OpeningBalance { get; set; }
    public int SuperTypeId { get; set; }
    public bool IsActive { get; set; }
    public string? OpeningBalanceDate { get; set; }
    public decimal? ExchangeRate { get; set; }
    public List<CompaniesData> CompaniesData { get; set; }
    public List<AccBudgetDto> AccBudget { get; set; }
    public string AccountCode { get; set; }
}

public class AccBudgetDto
{
    public decimal Amount { get; set; }
    public int PeriodId { get; set; }
}