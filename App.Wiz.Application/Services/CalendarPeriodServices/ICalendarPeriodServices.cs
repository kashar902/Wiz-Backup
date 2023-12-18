using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.AccountingBook;

namespace App.Wiz.Application.Services.CalendarPeriodServices;

public interface ICalendarPeriodServices
{
    Task<ServiceResponse> Add(CreateAccountBookCalendarPeriodDto request);
    Task<ServiceResponse> GetAll();
    Task<ServiceResponse> GetById(int request);
    Task<ServiceResponse> Update(UpdateAccountBookCalendarPeriodDto request);
    Task<ServiceResponse> Delete(int request);
    Task<ServiceResponse> ActivatePeriod(ActivateAccountBookCalendarPeriodDto request);
    Task<ServiceResponse> GetOnGeneralInfoId(int request);
}