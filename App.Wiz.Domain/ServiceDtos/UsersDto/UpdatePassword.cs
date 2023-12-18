namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class UpdatePassword
    {
        public int UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
