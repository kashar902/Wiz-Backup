using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CompanyViewModels;
using App.Wiz.Domain.Repositories.CompanyRepository;
using App.Wiz.Domain.ServiceDtos.CompanyDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.CompanyServices;

public class CompanyServices : ICompanyServices
{
    private readonly ICompanyRepository _repository;

    public CompanyServices(ICompanyRepository companyService)
    {
        _repository = companyService;
    }
    public async Task<ServiceResponse> CreateCompany(CreateCompanyDto dto)
    {
        _ = await _repository.AddAsync(new Company()
        {
            CompanyName = dto.CompanyName,
            CompanyDescription = dto.CompanyDescription,
            Masking = dto.Masking,
            StartDate = dto.StartDate,
            GroupOfCompanyId = dto.GroupOfCompanyId,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            CurrencyId = dto.CurrencyId,
            Active = dto.Active,
        });

        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> GetAllCompanies(bool active)
    {
        List<CompanyViewModel> companyViewModels = new();

        IList<Company> companies = active ? await _repository.GetAllActiveCompanies() : await _repository.GetAllCompaniesAsync();
        if (companies is not null)
        {
            foreach (Company item in companies)
            {
                CompanyViewModel companyViewModel = new()
                {
                    ID = item.ID,
                    CompanyName = item.CompanyName,
                    CompanyDescription = item.CompanyDescription,
                    Masking = item.Masking,
                    StartDate = item.StartDate,
                    GroupOfCompany = new GroupOfCompanyModel()
                    {
                        GroupOfCompanyId = item.GroupOfCompanyId,
                        GroupOfCompanyName = item.GroupOfCompanies!.GroupName,
                    },
                    Currency = new CurrencyModel()
                    {
                        CurrencyName = item.Currency!.CurrencyName,
                        CurrencyId = item.Currency.ID,
                    },
                    Active = item.Active,
                };
                companyViewModels.Add(companyViewModel);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, companyViewModels);
    }

    public async Task<ServiceResponse> GetSingleCompany(int id)
    {
        Company? company = await _repository.GetAsync(id);
        if (company is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        CompanyViewModel companyViewModel = new()
        {
            ID = company.ID,
            CompanyName = company.CompanyName,
            Masking = company.Masking,
            StartDate = company.StartDate,
            Active = company.Active,
            CompanyDescription = company.CompanyDescription,
            GroupOfCompany = new GroupOfCompanyModel()
            {
                GroupOfCompanyId = company.GroupOfCompanies!.GOCID,
                GroupOfCompanyName = company.GroupOfCompanies.GroupName
            },
            Currency = new CurrencyModel()
            {
                CurrencyName = company.Currency!.CurrencyName,
                CurrencyId = company.Currency.ID,
            }
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, companyViewModel);

    }

    public async Task<ServiceResponse> UpdateCompany(UpdateCompanyDto companyDto)
    {
        Company? response = await _repository.GetAsync(x => x.ID == companyDto.ID);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        response.CompanyName = companyDto.CompanyName;
        response.CompanyDescription = companyDto.CompanyDescription;
        response.Masking = companyDto.Masking;
        response.StartDate = companyDto.StartDate;
        response.GroupOfCompanyId = companyDto.GroupOfCompanyId;
        response.ModifiedBy = Global.Username;
        response.ModifiedDate = DateTime.UtcNow;
        response.CurrencyId = companyDto.CurrencyId;
        response.Active = companyDto.Active;

        await _repository.UpdateAsync(response);

        return ServiceResponse.Success(Constants.UpdateSuccessful);

    }

    public async Task<ServiceResponse> DeleteCompany(int id)
    {

        Company? response = await _repository.GetAsync(x => x.ID == id);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _repository.DeleteAsync(response);

        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }
}
