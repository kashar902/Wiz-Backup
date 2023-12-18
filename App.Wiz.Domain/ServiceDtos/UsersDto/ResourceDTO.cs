namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class ResourceDTO
    {
        public int ResourceId { get; set; }
        public bool IsCreated { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
}
