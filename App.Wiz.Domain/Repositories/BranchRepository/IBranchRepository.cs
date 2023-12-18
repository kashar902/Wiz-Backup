using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.BranchRepository
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task AddBranch(Branch branch);
        Task DeleteBranch(Branch branch);
        Task<List<Branch>> GetAllBranches();
        Task<List<Branch>> GetBranchesByCompanyId(int companyId);
        Task<Branch?> GetSingleBranch(int id);
        Task UpdateBranchAsync(Branch branch);
    }
}