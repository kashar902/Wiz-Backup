using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
