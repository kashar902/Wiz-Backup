using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CreditTermViewModels;
using App.Wiz.Domain.Repositories.CreditTermRepository;
using App.Wiz.Domain.ServiceDtos.CreditTermDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.CreditTermServices;

public class CreditTermService : ICreditTermService
{

    private readonly ICreditTermRepository _repository;
    public CreditTermService(ICreditTermRepository repo)
    {
        _repository = repo;
    }
    public async Task<ServiceResponse> CreateCreditTerm(CreateCreditTermDto creditTermDto)
    {
        CreditTerm creditTerm = new()
        {
            Title = creditTermDto.Title,
            Description = creditTermDto.Description,
            Term = creditTermDto.Term,
            CreatedBy = creditTermDto.CreatedBy,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = creditTermDto.CreatedBy,
            ModifiedDate = DateTime.UtcNow,
            TermUnit = creditTermDto.TermUnit
        };
        _ = await _repository.AddAsync(creditTerm);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> UpdateCreditTerm(UpdateCreditTermDto updateCreditTermDto)
    {
        CreditTerm? creditTerm = await _repository.GetAsync(x => x.ID == updateCreditTermDto.Id);
        if (creditTerm is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        creditTerm.Title = updateCreditTermDto.Title;
        creditTerm.Term = updateCreditTermDto.Term;
        creditTerm.Description = updateCreditTermDto.Description;
        creditTerm.TermUnit = updateCreditTermDto.TermUnit;
        creditTerm.ModifiedBy = updateCreditTermDto.ModifiedBy;
        creditTerm.ModifiedDate = DateTime.UtcNow;

        return ServiceResponse.Success(Constants.UpdateSuccessful);

    }
    public async Task<ServiceResponse> GetCreditTerm(int Id)
    {
        CreditTerm? creditTerm = await _repository.GetAsync(x => x.ID == Id);
        if (creditTerm is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        CreditTermViewModel creditTermViewModel = MapModelOnViewModel(creditTerm);

        return ServiceResponse.Success(Constants.LoadDataSuccess, creditTermViewModel);

    }
    public async Task<ServiceResponse> GetAllCreditTerms()
    {
        List<CreditTermViewModel> creditTermViewModels = new();
        IList<CreditTerm> creditTerms = await _repository.GetAllAsync();

        if (creditTerms != null)
        {
            foreach (CreditTerm creditTerm in creditTerms)
            {
                CreditTermViewModel creditTermViewModel = MapModelOnViewModel(creditTerm);
                creditTermViewModels.Add(creditTermViewModel);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, creditTermViewModels);

    }
    public async Task<ServiceResponse> DeleteCreditTerm(int id)
    {
        CreditTerm? creditTerm = await _repository.GetAsync(x => x.ID == id);
        if (creditTerm is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _repository.DeleteAsync(creditTerm);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }

    private static CreditTermViewModel MapModelOnViewModel(CreditTerm credit)
    {
        return new CreditTermViewModel
        {
            Id = credit.ID,
            Title = credit.Title,
            Term = credit.Term,
            Description = credit.Description,
            TermUnit = credit.TermUnit
        };
    }
}
