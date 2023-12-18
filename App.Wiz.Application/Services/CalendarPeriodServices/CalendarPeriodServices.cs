using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CalenderPeriodViewModels;
using App.Wiz.Domain.Repositories.AccountBookCalendarPeriodRepository;
using App.Wiz.Domain.ServiceDtos.AccountingBook;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.CalendarPeriodServices;

public class CalendarPeriodServices : ICalendarPeriodServices
{
    private readonly IAccountBookCalendarPeriodRepository _repository;

    public CalendarPeriodServices(IAccountBookCalendarPeriodRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse> Add(CreateAccountBookCalendarPeriodDto request)
    {
        AccountBookCalendarPeriod model = new()
        {
            Title = request.Title,
            CompanyId = request.CompanyId,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = false,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
        AccountBookCalendarPeriod? value = await _repository.AddAsync(model);
        return (value.ID != 0)
            ? ServiceResponse.Success(Constants.AddSuccessful)
            : ServiceResponse.Failure(Constants.Error);
    }

    public async Task<ServiceResponse> Update(UpdateAccountBookCalendarPeriodDto request)
    {
        AccountBookCalendarPeriod? response = await _repository.GetAsync(x => x.ID == request.Id);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        response.Title = request.Title;
        response.CompanyId = request.CompanyId;
        response.Description = request.Description;
        response.StartDate = request.StartDate;
        response.EndDate = request.EndDate;
        response.Status = request.Status;
        response.ModifiedBy = Global.Username;
        response.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(response);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }

    public async Task<ServiceResponse> GetAll()
    {
        return ServiceResponse.Success(Constants.LoadDataSuccess, await _repository.GetAll());
    }

    public async Task<ServiceResponse> GetById(int request)
    {
        AccountBookCalendarPeriod? response = await _repository.GetAsync(x => x.ID == request);
        return response is null
            ? ServiceResponse.Failure(Constants.NotFound)
            : ServiceResponse.Success(Constants.LoadDataSuccess, new AccountBookCalendarPeriodViewModel()
            {
                Title = response.Title,
                Description = response.Description,
                StartDate = response.StartDate,
                EndDate = response.EndDate,
                Status = response.Status,
                ID = response.ID,
                CompanyName = response.Company!.CompanyName
            });
    }

    public async Task<ServiceResponse> GetOnGeneralInfoId(int request)
    {
        IEnumerable<AccountBookCalendarPeriod> responses = await _repository.GetOnGeneralInfoId(request);
        return responses is null
            ? ServiceResponse.Failure(Constants.NotFound)
            : ServiceResponse.Success(Constants.LoadDataSuccess, responses
                .Select(response => new AccountBookCalendarPeriodViewModel
                {
                    Title = response.Title,
                    Description = response.Description,
                    StartDate = response.StartDate,
                    EndDate = response.EndDate,
                    Status = response.Status,
                    ID = response.ID,
                    CompanyName = response.Company!.CompanyName
                })
            .ToList());
    }

    public async Task<ServiceResponse> Delete(int request)
    {
        AccountBookCalendarPeriod? response = await _repository.GetAsync(x => x.ID == request);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        await _repository.DeleteAsync(response);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }

    public async Task<ServiceResponse> ActivatePeriod(ActivateAccountBookCalendarPeriodDto request)
    {
        AccountBookCalendarPeriod? activePeriod = await _repository.GetActivePeriod();
        if (activePeriod is not null)
        {
            if (activePeriod.ID == request.Id)
            {
                return ServiceResponse.Success(Constants.AlreadyActivate);
            }

            activePeriod.Status = false;
            activePeriod.ModifiedBy = Global.Username;
            activePeriod.ModifiedDate = DateTime.UtcNow;
            await _repository.UpdateAsync(activePeriod);
        }
        AccountBookCalendarPeriod? response = await _repository.GetAsync(x => x.ID == request.Id);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        response.Status = true;
        response.ModifiedBy = Global.Username;
        response.ModifiedDate = DateTime.UtcNow;
        await _repository.UpdateAsync(response);

        return ServiceResponse.Success(Constants.ActivateSuccessful);
    }

}