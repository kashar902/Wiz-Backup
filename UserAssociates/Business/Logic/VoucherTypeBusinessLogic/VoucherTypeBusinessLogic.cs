using Commons.Messages;
using UserAssociates.Business.Dtos.VoucherType;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.VoucherTypeService;

namespace UserAssociates.Business.Logic.VoucherTypeBusinessLogic
{
    public class VoucherTypeBusinessLogic : IVoucherTypeBusinessLogic
	{
		private readonly IVoucherTypeService _voucherTypeService;
		public VoucherTypeBusinessLogic(IVoucherTypeService voucherTypeService)
		{
			_voucherTypeService = voucherTypeService;
		}
		public async Task<string> CreateVoucherType(CreateVoucherTypeDto voucherTypeDto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(voucherTypeDto.Title) || string.IsNullOrWhiteSpace(voucherTypeDto.Type)
					|| string.IsNullOrWhiteSpace(voucherTypeDto.Prefix))
				{
					return Constants.IsNullValue;
				}
				VoucherType voucherType = new()
				{
					Prefix = voucherTypeDto.Prefix,
					Type = voucherTypeDto.Type,
					Title = voucherTypeDto.Title,
				};
				_ = await _voucherTypeService.AddVoucherType(voucherType);
				return Constants.VoucherType.CreateSuccessfull;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<string> UpdateVoucherType(UpdateVoucherTypeDto updateVoucherTypeDto)
		{
			try
			{
				VoucherType? voucherType = await _voucherTypeService.GetVoucherType(updateVoucherTypeDto.Id);
				if (voucherType is null)
				{
					return Constants.NotFound;
				}

				if (!string.IsNullOrWhiteSpace(updateVoucherTypeDto.Prefix))
				{
					voucherType.Prefix = updateVoucherTypeDto.Prefix;
				}

				if (!string.IsNullOrWhiteSpace(updateVoucherTypeDto.Title))
				{
					voucherType.Title = updateVoucherTypeDto.Title;
				}

				if (!string.IsNullOrWhiteSpace(updateVoucherTypeDto.Type))
				{
					voucherType.Type = updateVoucherTypeDto.Type;
				}

				int successCount = await _voucherTypeService.UpdateVoucherType(voucherType);
				return successCount != 0 ? Constants.VoucherType.UpdateSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<VoucherTypeViewModel?> GetVoucherType(int Id)
		{
			try
			{
				VoucherType? voucherType = await _voucherTypeService.GetVoucherType(Id);
				if (voucherType is null)
				{
					return null;
				}

				VoucherTypeViewModel voucherTypeViewModel = new()
				{
					Id = voucherType.ID,
					Type = voucherType.Type,
					Title = voucherType.Title,
					Prefix = voucherType.Prefix
				};
				return voucherTypeViewModel;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<List<VoucherType>> GetAllVoucherTypes()
		{
			try
			{
				return await _voucherTypeService.GetAllVoucherTypes();
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<string> DeleteVoucherType(int id)
		{
			try
			{
				VoucherType? voucherType = await _voucherTypeService.GetVoucherType(id);
				if (voucherType is null)
				{
					return Constants.NotFound;
				}

				int successCount = await _voucherTypeService.DeleteVoucherType(voucherType);
				return successCount != 0 ? Constants.VoucherType.DeleteSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}
	}
}