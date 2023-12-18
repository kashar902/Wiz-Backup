using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VoucherService
{
    public class VoucherSService : IVoucherSService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public VoucherSService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<VoucherSMS>> GetAllVoucherSMS()
        {
            var voucherSms = await _dbContext.Userpref_VoucherSMS.ToListAsync();
            return voucherSms;
        }
    }
}
