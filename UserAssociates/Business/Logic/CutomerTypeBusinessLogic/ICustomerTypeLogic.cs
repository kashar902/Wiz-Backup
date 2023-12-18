using UserAssociates.Business.Dtos.CustomerTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CutomerTypeBusinessLogic
{
    public interface ICustomerTypeLogic
    {
        Task<string> CreateCustomerType(CreateCustomerTypeDto createCustomerTypeDto);
        Task<string> UpdateCustomerType(UpdateCustomerTypeDto updateCustomerTypeDto);
        Task<CustomerTypeViewModel?> GetCustomerType(int Id);
        Task<List<CustomerType>> GetAllCustomerTypes();
        Task<string> DeleteCustomerType(int id);
    }
}
