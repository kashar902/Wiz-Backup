using App.Wiz.Common.ServiceViewModels.CalenderPeriodViewModels;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.AccountBookCalendarPeriodRepository;

public class AccountBookCalendarPeriodRepository : Repository<AccountBookCalendarPeriod>, IAccountBookCalendarPeriodRepository
{
    public AccountBookCalendarPeriodRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<IEnumerable<AccountBookCalendarPeriodViewModel>> GetAll()
    {
        List<AccountBookCalendarPeriodViewModel> viewModel =
            await _dbContext
                .AccountBookCalenderPeriods.Include(x => x.Company)
                .Select(u => new AccountBookCalendarPeriodViewModel
                {
                    CompanyName = u.Company!.CompanyName,
                    ID = u.ID,
                    Title = u.Title,
                    Description = u.Description,
                    StartDate = u.StartDate,
                    EndDate = u.EndDate,
                    Status = u.Status,
                })
                .ToListAsync();

        return viewModel;
    }
    public async Task<IEnumerable<AccountBookCalendarPeriod>> GetOnGeneralInfoId(int id)
    {
        List<AccountBookCalendarPeriod> response =
            await _dbContext
                .AccountBookCalenderPeriods.Where(x => x.CompanyId == id)
                .ToListAsync();

        return response;
    }
    public async Task<AccountBookCalendarPeriod?> GetActivePeriod()
    {
        AccountBookCalendarPeriod? response =
            await _dbContext.AccountBookCalenderPeriods.Where(x => x.Status == true)
            .FirstOrDefaultAsync();

        return response;
    }
}
