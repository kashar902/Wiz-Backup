using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public interface IGroupOfCompanyRepository : IRepository<GroupOfCompany>
{
    Task<List<GroupOfCompany>> GetAllAsync(bool isActive);
    Task<List<GroupOfCompany>> GetAllGOC();
    Task<GroupOfCompany> GetGroupOfCompaniesByCompanyIds(List<BranchCompanyPair> branchCompanyPairs);
}