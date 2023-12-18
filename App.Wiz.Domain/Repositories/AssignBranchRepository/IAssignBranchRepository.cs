using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.AssignBranchRepository;

public interface IAssignBranchRepository : IRepository<AccAssignBranch>
{
    Task<List<AccAssignBranch>> GetAllAsync(int branchId);
    Task<List<AccAssignBranch>> GetAsync();
    Task<List<AccAssignBranch>> GetAsync(string parentId);
    Task<AccAssignBranch> GetAsync(int branchId);
    Task<AccAssignBranch> GetAsync(int branchId, string parentId);
    Task RemoveAsync(List<AccAssignBranch> entity);
}
