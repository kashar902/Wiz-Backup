using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystDateLockService
{
    public class CDLService : ICDLService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CDLService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystDateLock>> GetAllCatalystDateLock()
        {
            var catalystDateLockPref = await _dbContext.Userpref_DateLock.ToListAsync();
            return catalystDateLockPref;
        }
    }
}
