using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystCheckboxService
{
    public class CCService : ICCService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CCService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystCheckbox>> GetAllCatalystCheckbox()
        {
            var catalystCheckboxPref = await _dbContext.Userpref_CatCheckbox.ToListAsync();
            return catalystCheckboxPref;
        }
    }
}
