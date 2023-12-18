using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ResourceRepository;

public interface IUserResourceRepository : IRepository<UsersResource>
{
    Task<List<UsersResource>> GetAllAsync(int userId);
    Task<List<UsersResource>> GetAllAsync(int userId, int catId);
    Task<UsersResource?> GetAsync(int userId, int resourceId);
}
