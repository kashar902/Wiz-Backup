using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystNumberSchemeService
{
    public class CNSService : ICNSService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CNSService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystNumberScheme>> GetAllCatalystNumberScheme()
        {
            var catalystNumberSchemePref = await _dbContext.Userpref_InvoiceNumscheme.ToListAsync();
            return catalystNumberSchemePref;
        }
    }
}
