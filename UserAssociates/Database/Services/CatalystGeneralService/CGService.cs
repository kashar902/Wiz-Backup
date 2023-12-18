using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystGeneralService
{
    public class CGService : ICGService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CGService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CatalystGeneral>> GetAllCatalystGeneral()
        {
            var catalystGeneralPref = await _dbContext.Userpref_CatGeneral.ToListAsync();
            return catalystGeneralPref;
        }
    }
}
