using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisaSMSService
{
    public class VSService : IVSService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public VSService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<VisaSMS>> GetAllVisaSMS()
        {
            var visaSms = await _dbContext.Userpref_VisaSMS.ToListAsync();
            return visaSms;
        }
    }
}
