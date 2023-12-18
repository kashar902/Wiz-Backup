using UserAssociates.Database.Models;

namespace UserAssociates.Business.Dtos
{
    public class AssignMemberGroupDto
    {
        public List<UserDto> Users { get; set; }
        public int GroupID { get; set; }
        public int GroupPriorityToUser { get; set; }
    }

    public class UserDto
    {
        public int AuthenticationUserId { get; set; }
    }
}
