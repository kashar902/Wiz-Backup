using UserAssociates.Business.Dtos.VoucherType;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.VoucherTypeBusinessLogic
{
    public interface IVoucherTypeBusinessLogic
    {
        Task<string> CreateVoucherType(CreateVoucherTypeDto voucherTypeDto);
        Task<string> UpdateVoucherType(UpdateVoucherTypeDto updateVoucherTypeDto);
        Task<VoucherTypeViewModel?> GetVoucherType(int Id);
        Task<List<VoucherType>> GetAllVoucherTypes();
        Task<string> DeleteVoucherType(int id);
    }
}
