using App.Wiz.Common.Messages;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public class GroupOfCompanyRepository : Repository<GroupOfCompany>, IGroupOfCompanyRepository
{
    public GroupOfCompanyRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
    public async Task<List<GroupOfCompany>> GetAllAsync(bool isActive)
    {
        return await _dbContext.GroupOfCompanies.Include(x => x.Currency).Where(x => x.Active == isActive).ToListAsync();
    }
    public async Task<List<GroupOfCompany>> GetAllGOC()
    {
        return await _dbContext.GroupOfCompanies.Include(x => x.Currency).ToListAsync();
    }
    public async Task<GroupOfCompany> GetGroupOfCompaniesByCompanyIds(List<BranchCompanyPair> branchCompanyPairs)
    {
        if (branchCompanyPairs == null || !branchCompanyPairs.Any())
        {
            throw new ArgumentException(Constants.LoginMessage.BranchCompanyPairsException);
        }

        List<int> companyIds = branchCompanyPairs.Select(pair => pair.CompanyId.Value).Distinct().ToList();

        GroupOfCompany uniqueGroupOfCompanyIds = await _dbContext.Companies
            .Where(company => companyIds.Contains(company.ID))
            .Include(x => x.GroupOfCompanies)
            .Select(x => x.GroupOfCompanies)
            .Distinct().FirstOrDefaultAsync();

        return uniqueGroupOfCompanyIds;

    }
}
