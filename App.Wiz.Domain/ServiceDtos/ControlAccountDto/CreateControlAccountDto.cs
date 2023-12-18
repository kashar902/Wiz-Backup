using App.Wiz.Domain.ServiceDtos.AccAssignBranchDto;

namespace App.Wiz.Domain.ServiceDtos.ControlAccountDto;

public class CreateControlAccountDto
{
    public CreateControlAccountDto()
    {
        CompaniesData = new List<CompaniesData>();
    }
    public string Title { get; set; }
    public string? ParentAccountId { get; set; }
    public string AccountCode { get; set; }
    public int SuperTypeId { get; set; }
    public bool IsActive { get; set; }

    public List<CompaniesData> CompaniesData { get; set; }
}