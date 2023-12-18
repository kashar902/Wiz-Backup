using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.UserBusiness
{
    public interface IUserLogic
    {
        Task<List<User>> GetAllUser();
    }
}
