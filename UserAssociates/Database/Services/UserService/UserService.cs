using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public UserService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUser()
        {
            var user = await _dbContext.Users.ToListAsync();
            return user;
        }
    }
}
