using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
    }
}
