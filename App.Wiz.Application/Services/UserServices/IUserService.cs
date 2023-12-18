using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.UsersDto;

namespace App.Wiz.Application.Services.UserServices;

public interface IUserService
{
    Task<ServiceResponse> AddUserResource(UserResourceDto userResource);
    Task<ServiceResponse> AssignBranches(AssignBranchDto model);
    Task<ServiceResponse> AssignGroupsToUser(UserGroupDto userGroupDto);
    Task<ServiceResponse> ChangeUserStatus(int id);
    Task<ServiceResponse> CreateUser(CreateUserWithBranchListDto users);
    Task<ServiceResponse> DeleteUser(int id);
    Task<ServiceResponse> GetAllUsers();
    Task<ServiceResponse> GetProfile();
    Task<ServiceResponse> GetSingleUser(int id);
    Task<ServiceResponse> GetUserCompanies();
    Task<ServiceResponse> SetProfile(UpdateUserProfileDto updateUserProfileDto);
    Task<ServiceResponse> UpdateUser(UserDto userDto);
}
