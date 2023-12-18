using UserAssociates.Database.Models;

namespace UserAssociates.Business.Dtos
{
    public class AssignResourceGroupDto
    {
        public List<ResourceDto> Resources { get; set; }
        public int GroupID { get; set; }
        public int GroupPriorityToUser { get; set; }
    }

    public class ResourceDto
    {
        public int ID { get; set; }
    }
}
