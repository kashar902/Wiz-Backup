using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.VoucherBusiness
{
    public interface IVoucherSLogic
    {
        Task<List<VoucherSMS>> GetAllVoucherSMSPref();
    }
}
