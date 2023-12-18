using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.PackagesDto;

public class UpdatePackageDto : UpdateDtoBaseEntities
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? No_of_Users { get; set; }
}