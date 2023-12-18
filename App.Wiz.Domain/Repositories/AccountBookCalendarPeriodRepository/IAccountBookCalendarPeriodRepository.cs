using App.Wiz.Common.ServiceViewModels.CalenderPeriodViewModels;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.AccountBookCalendarPeriodRepository;

public interface IAccountBookCalendarPeriodRepository : IRepository<AccountBookCalendarPeriod>
{
    Task<AccountBookCalendarPeriod?> GetActivePeriod();
    Task<IEnumerable<AccountBookCalendarPeriodViewModel>> GetAll();
    Task<IEnumerable<AccountBookCalendarPeriod>> GetOnGeneralInfoId(int id);
}