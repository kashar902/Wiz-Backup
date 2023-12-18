using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.SuperTypeViewModels;
using App.Wiz.Domain.Repositories.CompanyRepository;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.SuperTypeRepository;
using App.Wiz.Infrastructure.Entities;
using System.Text.RegularExpressions;

namespace App.Wiz.Application.Services.SuperTypeServices;

public class SupertTypeService : ISupertTypeService
{
    private readonly ISuperTypeRepository _repository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IControlAccountRepository _controlAccountRepository;
    public SupertTypeService(ISuperTypeRepository repository,
        ICompanyRepository companyRepository,
        IControlAccountRepository controlAccountRepository)
    {
        _repository = repository;
        _companyRepository = companyRepository;
        _controlAccountRepository = controlAccountRepository;
    }

    public async Task<ServiceResponse> GetAllAsync()
    {
        IEnumerable<AccSuperType> superTypes = await _repository.GetAllAsync();
        SuperTypeViewModel superTypeViewModel = new();
        foreach (AccSuperType item in superTypes)
        {
            superTypeViewModel.SuperType.Add(new()
            {
                SuperTypeId = item.ID,
                SuperTypeName = item.Name,
            });
        }
        Company company = await _companyRepository.GetAsync(Global.CompanyId);
        if (company != null)
        {
            var accountCodes = await _controlAccountRepository.GetAllAccountCodeAsync();
            superTypeViewModel.Masking = PrepareMasking(company.Masking, accountCodes);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, superTypeViewModel);
    }

    private string PrepareMasking(string masking, List<string> accountCode)
    {
        var intAcountCodes = accountCode
            .Where(x => x.Length == masking.Length + 1 && int.TryParse(x, out _))
            .Select(x => int.Parse(x))
            .DefaultIfEmpty(0) // Provides a default value if sequence is empty
            .Max();

        if (intAcountCodes == 0)
        {
            return new string('1', 1) + new string('0', masking.Length - 1);
        }
        var originalCode = intAcountCodes.ToString().Substring(1);
        
        int firstDigit = int.Parse(originalCode[0].ToString()) + 1;

        if (firstDigit > 9)
        {
            return "-" + new string('-', originalCode.Length - 1);
        }

        string newFirstChar = firstDigit.ToString();
        
        return newFirstChar + new string('0', originalCode.Length - 1);
    }
}
