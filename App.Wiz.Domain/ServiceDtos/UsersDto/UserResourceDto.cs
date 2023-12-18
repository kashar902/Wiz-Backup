using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class UserResourceDto : CreateDtoBaseEntities
    {
        public UserResourceDto()
        {
            Resources = new List<ResourceDTO>();
        }
        public int userId { get; set; }
        public List<ResourceDTO> Resources { get; set; }
    }
}
