using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public interface IUserGroupRepository : IRepository<UserGroup>
{
    Task<List<UserGroup>> GetUserGroups(int userId);
}