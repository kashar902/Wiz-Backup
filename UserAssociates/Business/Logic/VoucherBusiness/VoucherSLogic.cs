using UserAssociates.Database.Models;
using UserAssociates.Database.Services.VoucherService;

namespace UserAssociates.Business.Logic.VoucherBusiness
{
    public class VoucherSLogic : IVoucherSLogic
    {
        private readonly IVoucherSService _voucherSmsService;

        public VoucherSLogic(IVoucherSService voucherSmsService)
        {
            _voucherSmsService = voucherSmsService;
        }
        public async Task<List<VoucherSMS>> GetAllVoucherSMSPref()
        {
            try
            {
                var value = await _voucherSmsService.GetAllVoucherSMS();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
