using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public interface IGroupDetailRepository : IRepository<GroupDetails>
{
    Task<List<GroupDetails>> GetAllByGroupIdAsync(int groupId);
}
