using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.GroupsDto;

public class CreateGroupDto : CreateDtoBaseEntities
{
    public string? GroupName { get; set; }
    public int GroupPriority { get; set; }
    public string? Description { get; set; }
    public List<CreateAssignResourcesToGroupDto>? createAssignResourcesToGroupDtos { get; set; }

    public Group PrepareEntity()
    {
        return new Group()
        {
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            Description = Description,
            GroupPriority = GroupPriority,
            GroupName = GroupName,
        };
    }
}
