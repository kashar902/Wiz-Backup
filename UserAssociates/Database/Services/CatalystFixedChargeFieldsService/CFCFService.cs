using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystFixedChargeFieldsService
{
    public class CFCFService : ICFCFService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public CFCFService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CatalystFixedChargeFields>> GetAllCatalystFixedChargeFields()
        {
            var catalystFixedChargeFields = await _dbContext.Userpref_ChargeFields.ToListAsync();
            return catalystFixedChargeFields;
        }
    }
}
