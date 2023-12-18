using Commons.Messages;
using UserAssociates.Business.Dtos.CustomerTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CustomerTypeService;

namespace UserAssociates.Business.Logic.CutomerTypeBusinessLogic
{
    public class CustomerTypeLogic : ICustomerTypeLogic
	{

		private readonly ICustomerTypeService _customerTypeService;
		public CustomerTypeLogic(ICustomerTypeService customerTypeService)
		{
			_customerTypeService = customerTypeService;
		}

		public async Task<string> CreateCustomerType(CreateCustomerTypeDto createCustomerTypeDto)
		{
			try
			{
				CustomerType customerType = new()
				{
					Description = createCustomerTypeDto.Description,
					TypeName = createCustomerTypeDto.TypeName,
				};
				_ = await _customerTypeService.AddCustomerType(customerType);

				return Constants.CustomerType.CreateSuccessfull;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<string> UpdateCustomerType(UpdateCustomerTypeDto updateCustomerTypeDto)
		{
			try
			{
				CustomerType? customerType = await _customerTypeService.GetCustomerType(updateCustomerTypeDto.Id);
				if (customerType is null)
				{
					return Constants.NotFound;
				}

				if (!string.IsNullOrWhiteSpace(updateCustomerTypeDto.TypeName))
				{
					customerType.TypeName = updateCustomerTypeDto.TypeName;
				}

				if (!string.IsNullOrWhiteSpace(updateCustomerTypeDto.Description))
				{
					customerType.Description = updateCustomerTypeDto.Description;
				}

				int successCount = await _customerTypeService.UpdateCustomerType(customerType);
				return successCount != 0 ? Constants.CustomerType.UpdateSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<CustomerTypeViewModel?> GetCustomerType(int Id)
		{
			try
			{
				CustomerType? customerType = await _customerTypeService.GetCustomerType(Id);
				if (customerType is null)
				{
					return null;
				}

				CustomerTypeViewModel customerTypeViewModel = new()
				{
					Description = customerType.Description,
					TypeName = customerType.TypeName,
					ID = Id,
				};
				return customerTypeViewModel;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<List<CustomerType>> GetAllCustomerTypes()
		{
			try
			{
				return await _customerTypeService.GetAllCustomerTypes();
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<string> DeleteCustomerType(int id)
		{
			try
			{
				CustomerType? customerType = await _customerTypeService.GetCustomerType(id);
				if (customerType is null)
				{
					return Constants.NotFound;
				}

				int successCount = await _customerTypeService.DeleteCustomerType(customerType);
				return successCount != 0 ? Constants.CustomerType.DeleteSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}
	}
}
