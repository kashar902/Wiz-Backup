using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VoucherService
{
    public interface IVoucherSService
    {
        Task<List<VoucherSMS>> GetAllVoucherSMS();
    }
}
