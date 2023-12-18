using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.AccessRightsRepository;

public class AccessRightsRepository : Repository<Accessright>, IAccessRightsRepository
{
    public AccessRightsRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Accessright?> GetAccessright(bool isRead, bool isCreate, bool isUpdate, bool isDelete) 
    {
        return await _dbContext.Accessrights.
            FirstOrDefaultAsync(x => 
            x.ReadPermission == isRead &&
            x.CreatePermission == isCreate &&
            x.UpdatePermission == isUpdate &&
            x.DeletePermission == isDelete
            );
    }
}
