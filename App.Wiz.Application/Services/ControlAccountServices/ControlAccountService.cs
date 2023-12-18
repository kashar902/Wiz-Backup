using App.Wiz.Application.Profiles.ControlAccountProfiles;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.CompanyViewModels;
using App.Wiz.Common.ServiceViewModels.ControlAccountViewModels;
using App.Wiz.Domain.Repositories.AccountSetupRepository;
using App.Wiz.Domain.Repositories.AssignBranchRepository;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.ServiceDtos.AccAssignBranchDto;
using App.Wiz.Domain.ServiceDtos.ControlAccountDto;
using App.Wiz.Infrastructure.Entities;
using static App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.ControlAccountServices;

public class ControlAccountService : IControlAccountService
{
    private readonly IControlAccountRepository _repository;
    private readonly ISubsidaryAccountRepository _subsidaryAccountRepository;
    private readonly IUsersBranchRepository _branchRepository;
    private readonly IAssignBranchRepository _assignBranchRepository;
    private readonly IAccountSetupRepository _accountSetupRepository;

    public ControlAccountService(IControlAccountRepository repository,
        IUsersBranchRepository branchRepository,
        IAssignBranchRepository assignBranchRepository,
        ISubsidaryAccountRepository subsidaryAccountRepository,
        IAccountSetupRepository accountSetupRepository)
    {
        _repository = repository;
        _branchRepository = branchRepository;
        _assignBranchRepository = assignBranchRepository;
        _subsidaryAccountRepository = subsidaryAccountRepository;
        _accountSetupRepository = accountSetupRepository;
    }

    public async Task<ServiceResponse> Get()
    {
        List<AccControlAccount> controlAccounts = new();
        IList<UsersBranch> userBranch = await _branchRepository.GetAllAsync(x => x.UserId == Global.UserId);
        foreach (UsersBranch item in userBranch)
        {
            IList<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAllAsync(x => x.BranchId == item.BranchId);
            foreach (AccAssignBranch assignBranch in assignBranches)
            {
                AccControlAccount? accControlAccount = !string.IsNullOrWhiteSpace(assignBranch.ParentId) ?
                    await _repository.GetAsync(assignBranch.ParentId) : null;
                if (accControlAccount is not null)
                {
                    if (!controlAccounts.Any(x => x.ID == accControlAccount.ID))
                    {
                        controlAccounts.Add(accControlAccount);
                    }
                }
            }
        }


        Dictionary<string, string> parentAccountTitles = new();

        foreach (AccControlAccount account in controlAccounts)
        {
            if (!parentAccountTitles.ContainsKey(account.ID.ToString()))
            {
                parentAccountTitles.Add(account.ID.ToString(), account.Title);
            }
        }


        List<ControlAccountViewModel> ControlAccountViewModels = new();
        foreach (AccControlAccount constrolAccount in controlAccounts)
        {
            ControlAccountViewModel controlAccountsResponse = ControlAccountMapper.ToControlAccountViewModel(constrolAccount);
            controlAccountsResponse.ParentAccount = !string.IsNullOrWhiteSpace(constrolAccount.ParentAccountId)
                ? parentAccountTitles.ContainsKey(constrolAccount.ParentAccountId)
                ? parentAccountTitles[constrolAccount.ParentAccountId]
                : ""
                : "";
            ControlAccountViewModels.Add(controlAccountsResponse);
        }
        return ServiceResponse.Success(LoadDataSuccess, ControlAccountViewModels);
    }

    public async Task<ServiceResponse> GetById(string id, bool isControlAccount)
    {
        AccControlAccount? accControlAccount = await _repository.GetAsync(x => x.ParentAccountId == id);
        bool check = false;
        if (accControlAccount == null)
        {
            AccSubsidaryAccount? accSubsidary = await _subsidaryAccountRepository.GetAsync(x => x.ControlAccountId == Guid.Parse(id));
            check = accSubsidary == null;
        }
        else
        {
            check = false;
        }


        string currentAccountCode;
        switch (isControlAccount)
        {
            #region If is Control Account
            case true: // If is Control Account
                string NewCode = string.Empty;
                IEnumerable<AccControlAccount> controlAccounts = await _repository.GetAllAsync(x => x.SuperType);
                AccControlAccount controlAccount = controlAccounts.FirstOrDefault(x => x.ID == Guid.Parse(id));
                currentAccountCode = controlAccount.AccountCode;
                List<int> listofChildCodes = GetChildAccountCodes(controlAccounts, id);
                if (listofChildCodes.Any())
                {
                    int maxChildCode = listofChildCodes.Max();
                    int newcode = IncrementValue(maxChildCode);
                    if (maxChildCode == newcode)
                    {
                        NewCode = new string('-', maxChildCode.ToString().Length - 1);
                    }
                    NewCode = newcode.ToString();
                }
                if (!listofChildCodes.Any())
                {
                    int zeroIndex = currentAccountCode.IndexOf('0');
                    NewCode = zeroIndex != -1
                        ? string.Concat(currentAccountCode.AsSpan(0, zeroIndex), "1", currentAccountCode.AsSpan(zeroIndex + 1))
                        : new string('-', currentAccountCode.Length - 1);
                }

                ControlAccountViewModel response = ControlAccountMapper.ToControlAccountViewModel(controlAccount);

                IList<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAsync(id);
                List<CompanyDataViewModel> viewModels = MapToCompanyDataViewModels(assignBranches.ToList());
                response.IsDeleteable = check;
                response.NewAccountCode = NewCode.Remove(startIndex: 0, count: 1);
                response.CompaniesData = viewModels;
                return ServiceResponse.Success(LoadDataSuccess, response);
            #endregion

            #region  If is Subsidiary Account

            case false:
                string NewSubCode = string.Empty;
                AccControlAccount? parentAccountDetails = await _repository.GetAsync(id);
                ControlAccountViewModel subResponse = ControlAccountMapper.ToControlAccountViewModel(parentAccountDetails);

                List<AccAssignBranch> assignedBranches = await _assignBranchRepository.GetAsync(id);
                List<CompanyDataViewModel> viewModel = MapToCompanyDataViewModels(assignedBranches.ToList());

                subResponse.IsDeleteable = check;
                subResponse.CurrencyId = Global.CurrencyId;
                subResponse.CompaniesData = viewModel;

                IList<AccSubsidaryAccount> subsidaryAccounts = await _subsidaryAccountRepository.GetAllAsync(x => x.ControlAccountId == Guid.Parse(id));
                int maxSubsidaryAccountCode = GetMaxSubsidaryAccountCode(subsidaryAccounts);
                
                if (maxSubsidaryAccountCode != 0)
                {
                    long newCode = maxSubsidaryAccountCode++;
                    NewSubCode = maxSubsidaryAccountCode.ToString();
                    subResponse.NewAccountCode = NewSubCode.Remove(startIndex: 0, count: 1);
                    return ServiceResponse.Success(LoadDataSuccess, subResponse);
                }
                long setCode = long.Parse(parentAccountDetails.AccountCode) + 1;
                subResponse.NewAccountCode = setCode.ToString();

                return ServiceResponse.Success(LoadDataSuccess, subResponse);

            #endregion
        }
    }
    public async Task<ServiceResponse> AddAsync(CreateControlAccountDto dto)
    {
        var ControlAccount = await _subsidaryAccountRepository.GetSubsidaryAccountByCode(dto.AccountCode);
        if (ControlAccount is not null)
        {
            return ServiceResponse.Failure("Account Code Already Exist.");
        }
        AccControlAccount entity = ControlAccountMapper.ToAccControlAccount(dto);
        _ = await _repository.AddAsync(entity);
        List<AccAssignBranch> assignBranches = new();
        foreach (CompaniesData item in dto.CompaniesData)
        {
            assignBranches.Add(new()
            {
                ParentId = entity.ID.ToString(),
                BranchId = item.Id,
                IsControlAccount = true,
                CompanyId = item.CompanyId,
            });
        }
        await _assignBranchRepository.AddAsync(assignBranches);
        return ServiceResponse.Success(AddSuccessful);
    }

    public async Task<ServiceResponse> ToggleActiveStatus(string controlAccountId)
    {
        AccControlAccount controlAccount = await _repository.GetAsync(x => x.ID == Guid.Parse(controlAccountId));
        if (controlAccount is null)
        {
            return ServiceResponse.Failure(NotExist);
        }
        controlAccount.IsActive = !controlAccount.IsActive;
        controlAccount.ModifiedDate = DateTime.UtcNow;
        controlAccount.ModifiedBy = Global.Username;
        await _repository.UpdateAsync(controlAccount);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateControlAccountDto dto)
    {
        var ControlAccount = await _subsidaryAccountRepository.GetSubsidaryAccountByCode(dto.AccountCode);
        if (ControlAccount is not null)
        {
            return ServiceResponse.Failure("Account Code Already Exist.");
        }
        AccControlAccount controlAccount = await _repository.GetAsync(x => x.ID == dto.ControlAccountId);
        if (controlAccount is null)
        {
            return ServiceResponse.Failure(NotExist);
        }
        controlAccount = ControlAccountMapper.ToAccControlAccount(dto, controlAccount);
        IList<AccAssignBranch> assignedBranches = await _assignBranchRepository.GetAllAsync(x => x.ParentId == dto.ControlAccountId.ToString());
        await _assignBranchRepository.DeleteAsync(assignedBranches.ToList());

        List<AccAssignBranch> assignBranches = new();
        foreach (CompaniesData item in dto.CompaniesData)
        {
            assignBranches.Add(new()
            {
                ParentId = controlAccount.ID.ToString(),
                BranchId = item.Id,
                IsControlAccount = true,
                CompanyId = item.CompanyId,
            });
        }
        await _assignBranchRepository.AddAsync(assignBranches);
        await _repository.UpdateAsync(controlAccount);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> DeleteAsync(string controlAccountId)
    {
        IList<AccControlAccount> checkDataExistance = await _repository.GetAllAsync(x => x.ParentAccountId == controlAccountId);
       var checkDataExistanceInAccount = await _accountSetupRepository.CheckControlAccountAsync(controlAccountId);
        if (checkDataExistance.Any() || checkDataExistanceInAccount)
        {
            return ServiceResponse.Failure(CanNotDeleteParent);
        }

        AccControlAccount controlAccount = await _repository.GetAsync(x => x.ID == Guid.Parse(controlAccountId));
        if (controlAccount is null)
        {
            return ServiceResponse.Failure(NotExist);
        }
        await _repository.DeleteAsync(controlAccount);
        return ServiceResponse.Success(DeleteSuccessful);
    }

    private static string RemoveSpecialChar(string input)
    {
        return new string(input.Where(char.IsDigit).ToArray());
    }

    private string GenerateNewAccountCode(AccControlAccount controlAccount, long Maxi)
    {
        string maxNumberInString = Maxi.ToString();
        string NewAccountCode = string.Empty;
        if (maxNumberInString.Length > 0)
        {
            char[] asds = maxNumberInString.ToCharArray(1, maxNumberInString.Length - 1);

            int loopCount = 0;

            if (controlAccount != null)
            {
                for (int i = 0; i < controlAccount.AccountCode.Length; i++)
                {
                    if (controlAccount.AccountCode[i] == '-')
                    {
                        NewAccountCode += "-";
                    }
                    else
                    {
                        NewAccountCode += asds[loopCount];
                        loopCount++;
                    }
                    if (loopCount > asds.Length)
                    {
                        NewAccountCode += asds[loopCount..];
                        break;
                    }
                }
            }
        }
        return NewAccountCode;
    }

    private List<CompanyDataViewModel> MapToCompanyDataViewModels(List<AccAssignBranch> assignBranches)
    {
        List<CompanyDataViewModel> viewModels = new();
        foreach (AccAssignBranch item in assignBranches)
        {
            viewModels.Add(new CompanyDataViewModel()
            {
                Id = item.Branch?.ID ?? 0,
                CompanyId = item.Company?.ID ?? 0,
                CompanyName = item.Company?.CompanyName ?? "",
                Name = item.Branch?.Name ?? "",
            });
        }
        return viewModels;
    }

    private int GetMaxSubsidaryAccountCode(IEnumerable<AccSubsidaryAccount> subsidaryAccounts)
    {
        return subsidaryAccounts
            .Select(x => RemoveSpecialChar(x.AccountCode))
            .Where(code => int.TryParse(code, out _))
            .Select(code => int.Parse(code))
            .DefaultIfEmpty(0)
            .Max();
    }

    private List<int> GetChildAccountCodes(IEnumerable<AccControlAccount> controlAccounts, string id)
    {
        return controlAccounts
            .Where(x => x.ParentAccountId == id)
            .Select(x => RemoveSpecialChar(x.AccountCode))
            .Select(code => int.TryParse(code, out int number) ? number : -1)
            .Where(number => number != -1)
            .ToList();
    }

    private static int IncrementValue(int originalValue)
    {
        string strValue = originalValue.ToString();
        char[] charArray = strValue.ToCharArray();

        for (int i = charArray.Length - 1; i >= 0; i--)
        {
            if (charArray[i] != '0')
            {
                if (charArray[i] == '9')
                {
                    break;
                }

                charArray[i]++;
                break;
            }
        }

        return int.Parse(new string(charArray));
    }
}
