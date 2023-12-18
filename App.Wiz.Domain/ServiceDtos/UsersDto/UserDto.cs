namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class UserDto
    {
        public int userId { get; set; }
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
