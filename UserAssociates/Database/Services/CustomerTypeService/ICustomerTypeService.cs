using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CustomerTypeService
{
    public interface ICustomerTypeService
    {
        Task<CustomerType> AddCustomerType(CustomerType customerType);
        Task<CustomerType?> GetCustomerType(int Id);
        Task<List<CustomerType>> GetAllCustomerTypes();
        Task<int> UpdateCustomerType(CustomerType customerType);
        Task<int> DeleteCustomerType(CustomerType customerType);
    }
}
