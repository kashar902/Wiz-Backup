using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.UserRepository;

public class RoleRepository : Repository<UserRole>, IRoleRepository
{
    public RoleRepository(CatalystWizDbContext context)
     :base (context) {
            
    }
}
