using App.Wiz.Common.Enums;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.DropdownViews;
using App.Wiz.Common.ServiceViewModels.UserViewModels;
using App.Wiz.Domain.Repositories.AccessRightsRepository;
using App.Wiz.Domain.Repositories.BranchRepository;
using App.Wiz.Domain.Repositories.GroupRepository;
using App.Wiz.Domain.Repositories.ResourceRepository;
using App.Wiz.Domain.Repositories.UserRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.Entities;
using static App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUsersBranchRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IGroupOfCompanyRepository _groupOfCompanyRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IAccessRightsRepository _accessRightsRepository;
    private readonly IUsersBranchRepository _userBranchRepository;
    private readonly IUserResourceRepository _userResourceRepository;


    public UserService(IUsersBranchRepository repository,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IGroupOfCompanyRepository groupOfCompanyRepository,
        IBranchRepository branchRepository,
        IUserGroupRepository userGroupRepository,
        IAccessRightsRepository accessRightsRepository,
        IUsersBranchRepository userBranchRepository,
        IUserResourceRepository userResourceRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _groupOfCompanyRepository = groupOfCompanyRepository;
        _branchRepository = branchRepository;
        _userGroupRepository = userGroupRepository;
        _accessRightsRepository = accessRightsRepository;
        _userBranchRepository = userBranchRepository;
        _userResourceRepository = userResourceRepository;
    }
    public async Task<ServiceResponse> GetProfile()
    {
        UsersBranch? userBranch = await _repository.GetAsync(Global.UserId, true);
        if (userBranch is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        UserProfileViewModel viewModel = new()
        {
            BranchId = userBranch.BranchId,
            UserId = userBranch.UserId,
            BranchName = userBranch.Branch?.Name,
            CompanyId = userBranch.CompanyId,
            CompanyName = userBranch.Companies?.CompanyName,
            GroupOfCompanyId = userBranch.GroupOfCompanyId,
            GroupOfCompanyName = userBranch.GroupOfCompany?.GroupName,
            Username = userBranch.User?.Username
        };
        return ServiceResponse.Success(LoadDataSuccess, viewModel);
    }

    public async Task<ServiceResponse> GetUserCompanies()
    {
        IList<UsersBranch>? GetAllUserCompanies = await _repository.GetAllAsync(x => x.Companies!);
        IEnumerable<Dropdown>? response = GetAllUserCompanies
                                            .Where(x => x.UserId == Global.UserId)
                                            .Select(x => new Dropdown()
                                            {
                                                Key = x.CompanyId,
                                                Value = x.Companies!.CompanyName
                                            });
        return ServiceResponse.Success(LoadDataSuccess, response);
    }

    public async Task<ServiceResponse> SetProfile(UpdateUserProfileDto updateUserProfileDto)
    {
        UsersBranch? userBranch = await _repository.GetAsync(updateUserProfileDto.UserId, updateUserProfileDto.BranchId);
        if (userBranch is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        userBranch.DefaultBranch = true;
        await _repository.UpdateAsync(userBranch);
        IList<UsersBranch> otherUserBranches = await _repository.GetAllAsync(x => x.BranchId != updateUserProfileDto.BranchId && x.UserId == updateUserProfileDto.UserId && x.DefaultBranch);
        foreach (UsersBranch item in otherUserBranches)
        {
            item.DefaultBranch = false;
            await _repository.UpdateAsync(userBranch);
        }
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> CreateUser(CreateUserWithBranchListDto users)
    {
        Users? existedUser = await _userRepository.GetAsync(x => x.EmailAddress == users.EmailAddress);
        if (existedUser != null)
        {
            _ = ServiceResponse.Failure(Constants.AlreadyExist);
        }

        Users userModel = new()
        {
            Username = users.Username!,
            Password = users.Password!,
            ConfirmPassword = users.ConfirmPassword!,
            DisplayName = users.DisplayName!,
            EmailAddress = users.EmailAddress!,
            PhoneNumber = users.PhoneNumber!,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            IsActive = users.IsActive,
        };
        Users value = await _userRepository.AddAsync(userModel);
        UserRole userRole = new()
        {
            RoleId = (int)UserRoles.AgencyUser,
            UserId = value.ID,
        };
        _ = await _roleRepository.AddAsync(userRole);

        return ServiceResponse.Success(AddSuccessful, value);
    }

    public async Task<ServiceResponse> AssignBranches(AssignBranchDto model)
    {
        List<UsersBranch> branches = await _repository.GetUserBranchesAsync(model.UserId);
        await _repository.DeleteAsync(branches);
        GroupOfCompany groupOfCompany = await _groupOfCompanyRepository.GetGroupOfCompaniesByCompanyIds(model.BranchCompanyPairs!);

        List<UsersBranch> ls = new();

        foreach (BranchCompanyPair branchCompanyPair in model.BranchCompanyPairs!)
        {
            int branchId = branchCompanyPair.BranchId ?? branchCompanyPair.BranchId.GetValueOrDefault();
            int companyId = branchCompanyPair.CompanyId ?? branchCompanyPair.CompanyId.GetValueOrDefault();
            UsersBranch usersBranchmodel = new()
            {
                UserId = model.UserId,
                BranchId = branchId,
                CompanyId = companyId,
                GroupOfCompanyId = groupOfCompany != null ? groupOfCompany.GOCID : 0,
                CreatedBy = Global.Username,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = Global.Username,
                ModifiedDate = DateTime.UtcNow,
                DefaultBranch = false,
            };
            ls.Add(usersBranchmodel);
        }
        ls.FirstOrDefault().DefaultBranch = true;
        await _userBranchRepository.AddAsync(ls);
        return ServiceResponse.Success(AddSuccessful);
    }

    public async Task<ServiceResponse> AssignGroupsToUser(UserGroupDto userGroupDto)
    {
        List<UserGroup> userGroups = new();
        int userID = userGroupDto.UserId;
        if (userID == 0)
        {
            return ServiceResponse.Failure(AddUnsuccessful);
        }

        IList<UserGroup> usgrp = await _userGroupRepository.GetAllAsync(x => x.UserId == userID);
        await _userGroupRepository.DeleteAsync(usgrp.ToList());
        foreach (var dto in userGroupDto.groupDetails.Where(x => x.IsChecked))
        {
            UserGroup existed = new()
            {
                GroupId = dto.GroupId,
                CreatedBy = Global.Username,
                CreatedDate = DateTime.UtcNow,
                ModifiedBy = Global.Username,
                ModifiedDate = DateTime.UtcNow,
                UserId = userID
            };
            userGroups.Add(existed);
        }
        await _userGroupRepository.AddAsync(userGroups);
        return ServiceResponse.Success(AddSuccessful);
    }

    public async Task<ServiceResponse> DeleteUser(int id)
    {
        Users? user = await _userRepository.GetAsync(x => x.ID == id);
        await _userRepository.DeleteAsync(user);
        return ServiceResponse.Success(DeleteSuccessful);
    }

    public async Task<ServiceResponse> GetAllUsers()
    {
        IList<Users> users = await _userRepository.GetAllAsync();
        List<UserViewModel> userList = new();
        foreach (Users item in users)
        {
            //UserRole userRole = await _userService.GetUserRole(item.ID);
            UsersBranch? agency = await _userBranchRepository.GetDefaultUserAgency(item.ID);
            UserViewModel userViewModel = new()
            {
                ID = item.ID,
                Agency = agency != null ? agency?.Branch?.Name : string.Empty,
                DisplayName = item.DisplayName,
                EmailAddress = item.EmailAddress,
                PhoneNumber = item.PhoneNumber,
                IsActive = item.IsActive.GetValueOrDefault(),
                UserName = item.Username,
                //UserRole = userRole?.Role?.Name
            };
            userList.Add(userViewModel);
        }
        return ServiceResponse.Success(LoadDataSuccess, userList);
    }

    public async Task<ServiceResponse> ChangeUserStatus(int id)
    {
        Users? user = await _userRepository.GetAsync(x => x.ID == id);
        if (user is null)
        {
            return ServiceResponse.Failure(NotExist);
        }
        user.IsActive = !user.IsActive;
        await _userRepository.UpdateAsync(user);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> GetSingleUser(int id)
    {
        Users? value = await _userRepository.GetAsync(x => x.ID == id);
        UserViewModel viewModels = new();
        viewModels = new UserViewModel()
        {
            UserName = value.Username,
            DisplayName = value.DisplayName,
            EmailAddress = value.EmailAddress,
            PhoneNumber = value.PhoneNumber,
            IsActive = value.IsActive.GetValueOrDefault(),
        };
        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }

    public async Task<ServiceResponse> UpdateUser(UserDto userDto)
    {
        Users? user = await _userRepository.GetAsync(x => x.ID == userDto.userId);
        if (user is null)
        {
            return ServiceResponse.Failure(NotExist);
        }
        user.DisplayName = userDto.DisplayName;
        user.PhoneNumber = userDto.PhoneNumber;
        user.IsActive = userDto.IsActive;
        user.ModifiedBy = Global.Username;
        user.ModifiedDate = DateTime.UtcNow;
        await _userRepository.UpdateAsync(user);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> AddUserResource(UserResourceDto userResource)
    {
        List<UsersResource> ls = new();
        foreach (ResourceDTO item in userResource.Resources!)
        {
            if (!item.IsRead && !item.IsDelete && !item.IsCreated && !item.IsUpdate)
            {
                continue;
            }
            Accessright? accessRights = await _accessRightsRepository.GetAccessright(item.IsRead, item.IsCreated, item.IsUpdate, item.IsDelete);
            UsersResource? existedResource = await _userResourceRepository.GetAsync(x => x.UserId == userResource.userId && x.ResourceId == item.ResourceId);
            if (existedResource is null)
            {
                existedResource = new()
                {
                    UserId = userResource.userId,
                    ResourceId = item.ResourceId,
                    CreatedBy = Global.Username,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = Global.Username,
                    ModifiedDate = DateTime.UtcNow,
                    RightsId = accessRights?.ID,
                };
                ls.Add(existedResource);
            }
            else
            {
                existedResource.RightsId = accessRights.ID;
                existedResource.ModifiedBy = Global.Username;
                existedResource.ModifiedDate = DateTime.UtcNow;
                await _userResourceRepository.UpdateAsync(existedResource);
            }
        }
        await _userResourceRepository.AddAsync(ls);
        return ServiceResponse.Success(AddSuccessful);
    }
}
