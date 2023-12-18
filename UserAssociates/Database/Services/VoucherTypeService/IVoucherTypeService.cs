using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VoucherTypeService
{
    public interface IVoucherTypeService
    {
        Task<VoucherType> AddVoucherType(VoucherType city);
        Task<int> DeleteVoucherType(VoucherType city);
        Task<List<VoucherType>> GetAllVoucherTypes();
        Task<VoucherType?> GetVoucherType(int Id);
        Task<int> UpdateVoucherType(VoucherType city);
    }
}
