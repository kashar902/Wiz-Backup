using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.GroupOfCompaniesDto;
using App.Wiz.Domain.ServiceDtos.GroupsDto;

namespace App.Wiz.Application.Services.GroupServices;

public interface IGroupService
{
    Task<ServiceResponse> AddGroupOfCompany(CreateGroupOfCompanyDto request);
    Task<ServiceResponse> AssignResourseToGroup(CreateGroupDto createGroupDto);
    Task<ServiceResponse> DeleteGroup(int id);
    Task<ServiceResponse> DeleteGroupOfCompany(int Id);
    Task<ServiceResponse> GetAllGroupOfCompany(bool active);
    Task<ServiceResponse> GetAllGroupOfCompany();
    Task<ServiceResponse> GetAllGroups();
    Task<ServiceResponse> GetGroupById(int groupId);
    Task<ServiceResponse> GetSingleGroupOfCompany(int Id);
    Task<ServiceResponse> GetUserGroups(int userId);
    Task<ServiceResponse> UpdateGroup(UpdateGroupDto dto);
    Task<ServiceResponse> UpdateGroupOfCompany(UpdateGroupOfCompanyDto request);
}
