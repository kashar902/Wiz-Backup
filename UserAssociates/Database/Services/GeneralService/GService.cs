using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.GeneralService
{
    public class GService : IGService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public GService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<General>> GetAllGeneralUserPref()
        {
            var catalystGeneralUserPref = await _dbContext.Userpref_General.ToListAsync();
            return catalystGeneralUserPref;
        }
    }
}
