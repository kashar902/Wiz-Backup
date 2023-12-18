using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystDefaultService
{
    public class CDService : ICDService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CDService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystDefault>> GetAllCatalystDefault()
        {
            var catalystDefaultPref = await _dbContext.Userpref_CatDefault.ToListAsync();
            return catalystDefaultPref;
        }
    }
}
