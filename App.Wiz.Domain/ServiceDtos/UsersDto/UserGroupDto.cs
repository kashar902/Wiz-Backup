using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class UserGroupDto : CreateDtoBaseEntities
    {
        public UserGroupDto()
        {
            groupDetails = new List<GroupDetail>();
        }
        public List<GroupDetail> groupDetails { get; set; }
        public int UserId { get; set; }
    }

    public class GroupDetail 
    {
        public int GroupId { get; set; }
        public bool IsChecked { get; set; }
    }
}
