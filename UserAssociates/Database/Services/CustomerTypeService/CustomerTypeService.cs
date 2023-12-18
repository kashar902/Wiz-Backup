using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CustomerTypeService
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public CustomerTypeService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerType> AddCustomerType(CustomerType customerType)
        {
            EntityEntry<CustomerType> entityEntry = await _dbContext.AddAsync(customerType);
            _ = await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<int> DeleteCustomerType(CustomerType customerType)
        {
            _ = _dbContext.CustomerTypes.Remove(customerType);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CustomerType>> GetAllCustomerTypes()
        {
            return await _dbContext.CustomerTypes.ToListAsync();
        }

        public async Task<CustomerType?> GetCustomerType(int Id)
        {
            return await _dbContext.CustomerTypes.FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<int> UpdateCustomerType(CustomerType customerType)
        {
            _dbContext.Entry(customerType).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

    }
}
