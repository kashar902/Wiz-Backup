using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.PackagesDto;

public class CreatePackageDto : BaseEntities
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? NooOfUsers { get; set; }
}