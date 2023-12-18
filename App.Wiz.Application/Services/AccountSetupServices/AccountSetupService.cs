using App.Wiz.Application.Profiles.AccountSetupProfile;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.AccountSetupViewModels;
using App.Wiz.Common.ServiceViewModels.DropdownViews;
using App.Wiz.Domain.Repositories.AccountSetupRepository;
using App.Wiz.Domain.Repositories.AssignBranchRepository;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.ServiceDtos.AccountSetupDto;
using App.Wiz.Infrastructure.Entities;
using static App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.AccountSetupServices;

public class AccountSetupService : IAccountSetupService
{
    private readonly IAccountSetupRepository _repository;
    private readonly IControlAccountRepository _controlAccountRepository;
    private readonly ISubsidaryAccountRepository _subsidaryAccountRepository;
    private readonly IUsersBranchRepository _branchRepository;
    private readonly IAssignBranchRepository _assignBranchRepository;

    public AccountSetupService(
        IAccountSetupRepository repository,
        IControlAccountRepository controlAccountRepository,
        ISubsidaryAccountRepository subsidaryAccountRepository,
        IUsersBranchRepository usersBranchRepository,
        IAssignBranchRepository assignBranchRepository)
    {
        _repository = repository;
        _controlAccountRepository = controlAccountRepository;
        _subsidaryAccountRepository = subsidaryAccountRepository;
        _branchRepository = usersBranchRepository;
        _assignBranchRepository = assignBranchRepository;
    }

    public async Task<ServiceResponse> Get()
    {
        IList<AccountSetup> accountSetups = await _repository.GetAllAsync();
        List<AccountSetupViewModel> viewModels = new();
        foreach (AccountSetup item in accountSetups)
        {
            AccountSetupViewModel viewModel = await AccountSetupProfile.PrepareToViewModel(item, _controlAccountRepository, _subsidaryAccountRepository);
            viewModels.Add(viewModel);
        }
        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }
    public async Task<ServiceResponse> Get(int id)
    {
        AccountSetup? accountSetups = await _repository.GetAsync(x => x.Id == id);
        if (accountSetups is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        AccountSetupViewModel viewModels = await AccountSetupProfile.PrepareToViewModel(accountSetups, _controlAccountRepository, _subsidaryAccountRepository);
        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }
    public async Task<ServiceResponse> Delete(int id)
    {
        AccountSetup? accountSetups = await _repository.GetAsync(x => x.Id == id);
        if (accountSetups is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        await _repository.DeleteAsync(accountSetups);
        return ServiceResponse.Success(DeleteSuccessful);
    }
    public async Task<ServiceResponse> Add(CreateAccountDto dto)
    {
        AccountSetup entity = dto.PrepareToEnttiy(); // AccountSetupProfile.PrepareToEntity(dto);
        _ = await _repository.AddAsync(entity);
        return ServiceResponse.Success(AddSuccessful);
    }
    public async Task<ServiceResponse> Update(UpdateAccountDto dto)
    {
        AccountSetup? accountSetups = await _repository.GetAsync(x => x.Id == dto.Id);
        if (accountSetups is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        AccountSetup entity = dto.PrepareToEnttiy(accountSetups); //AccountSetupProfile.PrepareToEntity(dto, accountSetups);
        await _repository.UpdateAsync(entity);
        return ServiceResponse.Success(UpdateSuccessful);
    }
    public async Task<ServiceResponse> GetAccountSetupForm()
    {


        GetAccountSetupFormModel viewModels = new();

        List<AccControlAccount> controlAccounts = new();
        IList<UsersBranch> userBranch = await _branchRepository.GetAllAsync(x => x.UserId == Global.UserId);
        foreach (UsersBranch item in userBranch)
        {
            IList<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAllAsync(x => x.BranchId == item.BranchId);
            foreach (AccAssignBranch assignBranch in assignBranches)
            {
                AccControlAccount? accControlAccount = !string.IsNullOrWhiteSpace(assignBranch.ParentId) ?
                    await _controlAccountRepository.GetAsync(assignBranch.ParentId) : null;
                if (accControlAccount is not null)
                {
                    if (!controlAccounts.Any(x => x.ID == accControlAccount.ID))
                    {
                        controlAccounts.Add(accControlAccount);
                    }
                }
            }
        }
        List<AccSubsidaryAccount> subsidaryAccounts = new List<AccSubsidaryAccount>();
        foreach (UsersBranch item in userBranch)
        {
            IList<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAllAsync(x => x.BranchId == item.BranchId);
            foreach (AccAssignBranch assignBranch in assignBranches)
            {
                AccSubsidaryAccount? accSubsidaryAccount = !string.IsNullOrWhiteSpace(assignBranch.ParentId) ?
                    await _subsidaryAccountRepository.Get(Guid.Parse(assignBranch.ParentId)) : null;
                if (accSubsidaryAccount is not null)
                {
                    if (!subsidaryAccounts.Any(x => x.ID == accSubsidaryAccount.ID))
                    {
                        subsidaryAccounts.Add(accSubsidaryAccount);
                    }
                }
            }
        }
       

        PopulateDropdowns(controlAccounts, viewModels.Customers);
        PopulateDropdowns(controlAccounts, viewModels.Suppliers);
        PopulateDropdowns(subsidaryAccounts, viewModels.VoidCharges);
        PopulateDropdowns(subsidaryAccounts, viewModels.BalanceEquities);
        PopulateDropdowns(subsidaryAccounts, viewModels.ExchangeDiffs);

        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }
    private void PopulateDropdowns(IEnumerable<AccControlAccount> accounts, List<GuidDropdown> list)
    {
        foreach (AccControlAccount item in accounts)
        {
            list.Add(new GuidDropdown
            {
                Key = item.ID,
                Value = item.Title
            });
        }
    }
    private void PopulateDropdowns(IEnumerable<AccSubsidaryAccount> accounts, List<GuidDropdown> list)
    {
        foreach (AccSubsidaryAccount item in accounts)
        {
            list.Add(new GuidDropdown
            {
                Key = item.ID,
                Value = item.Title
            });
        }
    }
}
