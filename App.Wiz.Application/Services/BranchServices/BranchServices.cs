using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.AgencyViewModels;
using App.Wiz.Domain.Repositories.BranchRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.ServiceDtos.AgencyDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.BranchServices;

public class BranchServices : IBranchServices
{
    private readonly IBranchRepository _repository;
    private readonly IUsersBranchRepository _userBranchRepository;

    public BranchServices(IBranchRepository repository, IUsersBranchRepository userBranchRepository)
    {
        _repository = repository;
        _userBranchRepository = userBranchRepository;
    }

    public async Task<ServiceResponse> AddAgency(CreateAgencyDto createAgencyDto)
    {
        await _repository.AddBranch(new Branch()
        {
            Name = createAgencyDto.Name!,
            PhoneNumber = createAgencyDto.PhoneNumber!,
            EmailAddress = createAgencyDto.EmailAddress!,
            IsActive = createAgencyDto.IsActive,
            officeAddress = createAgencyDto.OfficeAddress!,
            Postalcode = createAgencyDto.Postalcode!,
            CompanyId = createAgencyDto.CompanyId,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            CurrencyId = createAgencyDto.CurrencyId
        });
        return ServiceResponse.Success(Constants.AddSuccessful);

    }

    public async Task<ServiceResponse> UpdateActivestatus(UpdateAgencyDto agencyDto)
    {
        Branch? value = await _repository.GetSingleBranch(agencyDto.ID);
        if (value is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        value.Name = agencyDto.Name;
        value.Postalcode = agencyDto.Postalcode;
        value.PhoneNumber = agencyDto.PhoneNumber;
        value.CompanyId = agencyDto.CompanyId;
        value.officeAddress = agencyDto.OfficeAddress;
        value.EmailAddress = agencyDto.EmailAddress;
        value.IsActive = agencyDto.IsActive;
        value.CurrencyId = agencyDto.CurrencyId;
        await _repository.UpdateBranchAsync(value);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }

    public async Task<ServiceResponse> GetAllAgencies()
    {
        List<AgencyViewModel> list = new();

        List<Branch>? value = await _repository.GetAllBranches();
        foreach (Branch item in value)
        {
            AgencyViewModel agencyViewModel = new()
            {
                ID = item.ID,
                Name = item.Name,
                PhoneNumber = item.PhoneNumber,
                EmailAddress = item.EmailAddress,
                officeAddress = item.officeAddress,
                Postalcode = item.Postalcode,
                CompanyId = item.CompanyId,
                CompanyName = item.Company?.CompanyName,
                IsActive = item.IsActive,
                CurrencyId = item.CurrencyId,
                CurrencyName = item.Currency?.CurrencyName
            };
            list.Add(agencyViewModel);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, list);
    }
    public async Task<ServiceResponse> GetSingleAgency(int id)
    {
        Branch? value = await _repository.GetSingleBranch(id);
        if (value is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        AgencyViewModel model = new()
        {
            Name = value.Name,
            Postalcode = value.Postalcode,
            officeAddress = value.officeAddress,
            CompanyId = value.CompanyId,
            ID = value.ID,
            PhoneNumber = value.PhoneNumber,
            EmailAddress = value.EmailAddress,
            IsActive = value.IsActive,
            CompanyName = value.Company?.CompanyName,
            CurrencyId = value.CurrencyId,
            CurrencyName = value.Currency?.CurrencyName
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, model);
    }

    public async Task<ServiceResponse> DeleteAgency(int id)
    {
        Branch? value = await _repository.GetSingleBranch(id);
        if (value is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        await _repository.DeleteBranch(value);
        return ServiceResponse.Success(Constants.DeleteSuccessful);

    }
    public async Task<ServiceResponse> GetAgenciesByCompanyId(int companyId)
    {
        List<AgencyViewModel?> list = new();

        List<Branch> values = await _repository.GetBranchesByCompanyId(companyId);
        foreach (Branch item in values)
        {
            AgencyViewModel agencyViewModel = new()
            {
                ID = item.ID,
                Name = item.Name,
                PhoneNumber = item.PhoneNumber,
                EmailAddress = item.EmailAddress,
                officeAddress = item.officeAddress,
                Postalcode = item.Postalcode,
                CompanyId = item.CompanyId,
                IsActive = item.IsActive,
                CompanyName = item.Company?.CompanyName,
            };
            list.Add(agencyViewModel);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, list);

    }
    public async Task<ServiceResponse> GetAgenciesByUserId(int userId)
    {
        List<AgencyViewModel> list = new();

        List<UsersBranch> values = await _userBranchRepository.GetBranchesByUserId(userId);
        foreach (UsersBranch item in values)
        {
            Branch? branch = await _repository.GetSingleBranch(item.BranchId);
            if (branch != null)
            {
                AgencyViewModel agencyViewModel = new()
                {
                    ID = branch.ID,
                    Name = branch.Name,
                    PhoneNumber = branch.PhoneNumber,
                    EmailAddress = branch.EmailAddress,
                    officeAddress = branch.officeAddress,
                    Postalcode = branch.Postalcode,
                    CompanyId = branch.CompanyId,
                    IsActive = branch.IsActive,
                    CompanyName = branch.Company?.CompanyName
                };
                list.Add(agencyViewModel);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, list);
    }
}

