using App.Wiz.Application.Profiles.SubsidaryAccountProfiles;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.AccBudgetViewModels;
using App.Wiz.Common.ServiceViewModels.CompanyViewModels;
using App.Wiz.Common.ServiceViewModels.DropdownViews;
using App.Wiz.Common.ServiceViewModels.SubsidaryViewModels;
using App.Wiz.Domain.Repositories.AccountSetupRepository;
using App.Wiz.Domain.Repositories.AssignBranchRepository;
using App.Wiz.Domain.Repositories.BudgetRepository;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.ServiceDtos.AccAssignBranchDto;
using App.Wiz.Domain.ServiceDtos.SubsidiaryAccountDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.SubsidaryAccountServices;
public class SubsidaryAccountService : ISubsidaryAccountService
{
    private readonly ISubsidaryAccountRepository _service;
    private readonly IControlAccountRepository _controlAccountRepository;
    private readonly IBudgetRepository _accBudgetService;
    private readonly IUsersBranchRepository _branchRepository;
    private readonly IAssignBranchRepository _assignBranchRepository;
    private readonly IAccountSetupRepository _accountSetupRepository;

    public SubsidaryAccountService(IBudgetRepository accBudgetService,
        IAssignBranchRepository branchesService,
        ISubsidaryAccountRepository service,
        IUsersBranchRepository usersBranchRepository,
        IAccountSetupRepository accountSetupRepository,
        IControlAccountRepository controlAccountRepository)
    {
        _accBudgetService = accBudgetService;
        _assignBranchRepository = branchesService;
        _service = service;
        _branchRepository = usersBranchRepository;
        _accountSetupRepository = accountSetupRepository;
        _controlAccountRepository = controlAccountRepository;
    }

    public async Task<ServiceResponse> AddAsync(CreateSubsidiaryAccountDto dto)
    {
        var ControlAccount = await _controlAccountRepository.GetControlAccountByCodeAsync(dto.AccountCode);
        if (ControlAccount is not null)
        {
            return ServiceResponse.Failure("Account Code Already Exist.");
        }
        AccSubsidaryAccount entity = SubsidaryAccountMapper.ToAccSubsidaryAccount(dto);
        _ = await _service.AddAsync(entity);
        List<AccAssignBranch> assignBranches = new();
        foreach (CompaniesData item in dto.CompaniesData)
        {
            AccAssignBranch accAssignBranch = new()
            {
                ParentId = entity.ID.ToString(),
                BranchId = item.Id,
                IsControlAccount = false,
                CompanyId = item.CompanyId,
            };
            assignBranches.Add(accAssignBranch);
        }
        await _assignBranchRepository.AddAsync(assignBranches);
        List<AccBudget> budgets = new();
        foreach (AccBudgetDto item in dto.AccBudget)
        {
            AccBudget accBudget = new()
            {
                ParentId = entity.ID,
                BranchId = Global.BranchId,
                Amount = item.Amount,
                PeriodId = item.PeriodId,
                CreatedBy = Global.Username,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = Global.Username,
                ModifiedDate = DateTime.UtcNow
            };
            budgets.Add(accBudget);
        }
        await _accBudgetService.AddAsync(budgets);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> UpdateAsync(UpdateSubsidiaryAccountDto dto)
    {
        var ControlAccount = await _controlAccountRepository.GetControlAccountByCodeAsync(dto.AccountCode);
        if (ControlAccount is not null)
        {
            return ServiceResponse.Failure("Account Code Already Exist.");
        }
        AccSubsidaryAccount? subsidaryAccount = await _service.Get(dto.ID);
        if (subsidaryAccount is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        List<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAsync(dto.ID.ToString());
        await _assignBranchRepository.RemoveAsync(assignBranches);
        foreach (CompaniesData item in dto.CompaniesData)
        {
            AccAssignBranch accAssignBranch = new()
            {
                ParentId = dto.ID.ToString(),
                BranchId = item.Id,
                IsControlAccount = false,
                CompanyId = item.CompanyId,
            };
            _ = await _assignBranchRepository.AddAsync(accAssignBranch);
        }

        List<AccBudget> assignBudgets = await _accBudgetService.GetAsync(dto.ID);
        await _accBudgetService.RemoveAsync(assignBudgets);
        foreach (UpdateAccBudgetDto item in dto.AccBudget)
        {
            AccBudget accBudget = new()
            {
                ParentId = dto.ID,
                BranchId = Global.BranchId,
                Amount = item.Amount,
                PeriodId = item.PeriodId,
                CreatedBy = Global.Username,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = Global.Username,
                ModifiedDate = DateTime.UtcNow
            };
            _ = await _accBudgetService.AddAsync(accBudget);
        }
        AccSubsidaryAccount entity = SubsidaryAccountMapper.ToAccSubsidaryAccount(dto, subsidaryAccount);
        await _service.UpdateAsync(entity);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }

    public async Task<ServiceResponse> GetAll()
    {
        IList<UsersBranch> userBranch = await _branchRepository.GetAllAsync(x => x.UserId == Global.UserId);
        List<AccSubsidaryAccount> subsidaryAccounts = new();
        foreach (UsersBranch item in userBranch)
        {
            IList<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAllAsync(x => x.BranchId == item.BranchId);
            foreach (AccAssignBranch assignBranch in assignBranches)
            {
                AccSubsidaryAccount? accSubsidaryAccount = !string.IsNullOrWhiteSpace(assignBranch.ParentId) ?
                    await _service.Get(Guid.Parse(assignBranch.ParentId)) : null;
                if (accSubsidaryAccount is not null)
                {
                    if (!subsidaryAccounts.Any(x => x.ID == accSubsidaryAccount.ID))
                    {
                        subsidaryAccounts.Add(accSubsidaryAccount);
                    }
                }
            }
        }
        List<SubsidaryAccountViewModel> subsidaryAccountsList = new();
        foreach (AccSubsidaryAccount constrolAccount in subsidaryAccounts)
        {
            subsidaryAccountsList.Add(SubsidaryAccountMapper.ToSubsidaryAccountViewModel(constrolAccount));
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, subsidaryAccountsList);
    }
    public async Task<ServiceResponse> Get(Guid id)
    {
        AccSubsidaryAccount? subsidaryAccounts = await _service.Get(id);
        if (subsidaryAccounts == null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        SubsidaryAccountViewModel subsidaryAccount = SubsidaryAccountMapper.ToSubsidaryAccountViewModel(subsidaryAccounts);
        List<AccAssignBranch> assignBranches = await _assignBranchRepository.GetAsync(id.ToString());
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
        List<AccBudget> budgets = await _accBudgetService.GetAsync(id);
        List<AccBudgetViewModel> accBudgetViewModels = new();
        foreach (AccBudget item in budgets)
        {
            AccBudgetViewModel accBudgetViewModel = new()
            {
                Amount = item.Amount,
                PeriodId = item.PeriodId,
                Title = item.Period?.Title
            };
            accBudgetViewModels.Add(accBudgetViewModel);
        }
        subsidaryAccount.AccBudget = accBudgetViewModels;
        subsidaryAccount.CompaniesData = viewModels;
        return ServiceResponse.Success(Constants.LoadDataSuccess, subsidaryAccount);
    }
    public async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        AccSubsidaryAccount? subsidaryAccounts = await _service.Get(id);
        if (subsidaryAccounts is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        bool checkDataExistanceInAccount = await _accountSetupRepository.ChecksubsidaryAccountAsync(id.ToString());
        if (checkDataExistanceInAccount)
        {
            return ServiceResponse.Failure(Constants.CanNotDeleteParent);
        }
        _ = await _service.RemoveAsync(subsidaryAccounts);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }
    public async Task<ServiceResponse> GetAllBudgetPeriod()
    {
        return ServiceResponse.Success(Constants.LoadDataSuccess, await _service.GetAllBudegetPeriod());
    }
    public async Task<ServiceResponse> GetBudgetPeriod(int id)
    {
        AccBudgetPeriod? budgetPeriod = await _service.GetBudegetPeriod(id);
        return budgetPeriod is null
            ? ServiceResponse.Failure(Constants.NotExist)
            : ServiceResponse.Success(Constants.LoadDataSuccess, budgetPeriod);
    }
    public async Task<ServiceResponse> GetCustomerSupplierDropDown()
    {
        List<AccSubsidaryAccount> subsidaryAccounts = await _service.GetAll();
        _ = new List<GuidDropdown>();
        List<GuidDropdown> guidDropdowns = PrepareStaticDropdown();

        foreach (AccSubsidaryAccount item in subsidaryAccounts)
        {
            GuidDropdown guidDropdown = new()
            {
                Key = item.ID,
                Value = item.Title
            };
            guidDropdowns.Add(guidDropdown);
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, guidDropdowns);
    }
    private List<GuidDropdown> PrepareStaticDropdown()
    {
        return new List<GuidDropdown>()
        {
            new()
            {
                Key = Constants.CustomerKey,
                Value = Constants.Customer
            },
            new()
            {
                Key = Constants.SupplierKey,
                Value = Constants.Supplier
            }
        };
    }
}
