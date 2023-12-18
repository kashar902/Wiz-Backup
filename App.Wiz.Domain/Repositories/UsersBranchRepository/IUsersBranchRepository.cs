using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.UsersBranchRepository;

public interface IUsersBranchRepository : IRepository<UsersBranch>
{
    Task<UsersBranch?> GetAsync(int userId);
    Task<UsersBranch?> GetAsync(int userId, bool defaultBranch);
    Task<UsersBranch?> GetAsync(int userId, int branchId);
    Task<List<UsersBranch>> GetBranchesByUserId(int userId);
    Task<UsersBranch?> GetDefaultUserAgency(int userId);
    Task<List<UsersBranch>> GetUserBranchesAsync(int userId);
}