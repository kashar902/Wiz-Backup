using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.ResourceDto;
using App.Wiz.Domain.ServiceDtos.UsersDto;

namespace App.Wiz.Application.Services.ResourceServices;

public interface IResourcesService
{
    Task<ServiceResponse> AddResource(CreateResourceDto dto);
    Task<ServiceResponse> GetAllResources();
    Task<ServiceResponse> GetRightsDataOnPath(GetRightsDto dto);
    Task<ServiceResponse> GetUserFormResources(int userId);
    Task<ServiceResponse> GetUserResources(int userId);
    Task<ServiceResponse> GetUserResourcesV2(int userId);
}
