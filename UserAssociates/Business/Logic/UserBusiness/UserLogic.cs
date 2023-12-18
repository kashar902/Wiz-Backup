using UserAssociates.Database.Models;
using UserAssociates.Database.Services.UserService;

namespace UserAssociates.Business.Logic.UserBusiness
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserService _userService;

        public UserLogic(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<List<User>> GetAllUser()
        {
            try
            {
                var value = await _userService.GetAllUser();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
