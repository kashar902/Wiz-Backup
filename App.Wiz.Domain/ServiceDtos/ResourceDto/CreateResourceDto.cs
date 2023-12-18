using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.ResourceDto;

public class CreateResourceDto : CreateDtoBaseEntities
{
    public int ID { get; set; }
    public string? ResourceName { get; set; }
    public bool IsCreated { get; set; }
    public bool IsRead { get; set; }
    public bool IsUpdate { get; set; }
    public bool IsDelete { get; set; }
}