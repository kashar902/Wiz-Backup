using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.GroupsDto;

public class UpdateGroupDto : UpdateDtoBaseEntities
{
    public UpdateGroupDto()
    {
        createAssignResourcesToGroupDtos = new List<CreateAssignResourcesToGroupDto>();
    }
    public int GroupId { get; set; }
    public string? GroupName { get; set; }
    public int GroupPriority { get; set; }
    public string? Description { get; set; }
    public List<CreateAssignResourcesToGroupDto> createAssignResourcesToGroupDtos { get; set; }

    public Group PrepareEntity() 
    {
        return new Group()
        {
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            Description = Description,
            GroupName = GroupName,
            GroupPriority = GroupPriority,
            ID = GroupId
        };
    }

}
