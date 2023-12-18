using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystBranchPrefService
{
    public class CBPService : ICBPService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CBPService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystBranchPreferences>> GetAllCatalystBranchPreferences()
        {
            var catalystBranchPref = await _dbContext.Userpref_BranchPreferences.ToListAsync();
            return catalystBranchPref;
        }
    }
}
