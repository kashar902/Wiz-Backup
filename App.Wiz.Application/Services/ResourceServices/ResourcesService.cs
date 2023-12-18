using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.ResourcesCategoryViewModel;
using App.Wiz.Common.ServiceViewModels.ResourcesViewModels;
using App.Wiz.Common.ServiceViewModels.RightsPermissionsViewModels;
using App.Wiz.Domain.Repositories.GroupRepository;
using App.Wiz.Domain.Repositories.ResourceRepository;
using App.Wiz.Domain.ServiceDtos.ResourceDto;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.Entities;
using Constants = App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.ResourceServices;

public class ResourcesService : IResourcesService
{
    private readonly IResourcesRepository _resourcesRepository;
    private readonly IResourceCategoryRepository _resourceCategoryRepository;
    private readonly IUserResourceRepository _userResourceRepository;
    private readonly IUserGroupRepository _userGroupRepository;

    public ResourcesService(IResourcesRepository resourcesRepository,
        IResourceCategoryRepository resourceCategoryRepository,
        IUserResourceRepository userResourceRepository,
        IUserGroupRepository userGroupRepository)
    {
        _resourcesRepository = resourcesRepository;
        _resourceCategoryRepository = resourceCategoryRepository;
        _userResourceRepository = userResourceRepository;
        _userGroupRepository = userGroupRepository;
    }
    public async Task<ServiceResponse> GetUserResources(int userId)
    {
        UserAssignedResourcesViewModel viewModel = new();
        List<ResourceCategory> resourceCategories = new();
        IList<UserGroup> userGroup = await _userGroupRepository.GetUserGroups(userId);
        IList<ResourcesCategory> dbResourceCategories = await _resourceCategoryRepository.GetAllAsync();
        foreach (ResourcesCategory item in dbResourceCategories)
        {
            ResourceCategory resourceCategory = new()
            {
                Priority = item.Priority,
                children = new List<Resources>(),
                Icon = item.Icon,
                Path = item.Path,
                Title = item.Title,
                Type = item.Type,
                ID = item.ID,
            };
            resourceCategories.Add(resourceCategory);
        }
        List<Resources> resources = new();
        foreach (ResourceCategory item in resourceCategories)
        {
            IList<UsersResource> userResources = await _userResourceRepository.GetAllAsync(userId, item.ID);
            foreach (UsersResource usersResource in userResources)
            {
                Resources resource = new()
                {
                    Icon = usersResource.Resource?.Icon,
                    Path = usersResource.Resource?.Path,
                    Title = usersResource.Resource?.ResourceName,
                    Type = usersResource.Resource?.Type,
                    CategoryId = usersResource.Resource?.CategoryId
                };
                resources.Add(resource);
            }
            item.children = resources;
            viewModel.MenuItems.Add(item);
            resources = new List<Resources>();
        }
        IOrderedEnumerable<ResourceCategory> orderByList = viewModel.MenuItems
            .OrderBy(x => x.Priority);
        return ServiceResponse.Success(Constants.LoadDataSuccess, orderByList);
    }

    public async Task<ServiceResponse> GetRightsDataOnPath(GetRightsDto dto)
    {
        Resource? resource = await _resourcesRepository.GetAsync(x => x.Path == dto.Path);
        if (resource is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        UsersResource? usersResource = await _userResourceRepository.GetAsync(dto.UserId, resource.ID);

        if (usersResource is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        HasPermissionViewModel viewModel = new()
        {
            ResourceId = resource.ID,
            CreatePermission = usersResource.Rights?.CreatePermission,
            DeletePermission = usersResource.Rights?.DeletePermission,
            UpdatePermission = usersResource.Rights?.UpdatePermission,
            ReadPermission = usersResource.Rights?.ReadPermission
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModel);
    }

    public async Task<ServiceResponse> AddResource(CreateResourceDto dto)
    {
        Resource resource = new()
        {
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ResourceName = dto.ResourceName,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow
        };
        _ = await _resourcesRepository.AddAsync(resource);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> GetAllResources()
    {
        List<ResourcesRightsViewModel> resourcesViewModels = new();
        IList<Resource> value = await _resourcesRepository.GetAllAsync();
        foreach (Resource item in value)
        {
            ResourcesRightsViewModel resourcesViewModel = new()
            {
                ResourceId = item.ID,
                ResourceName = item.ResourceName
            };
            resourcesViewModels.Add(resourcesViewModel);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, resourcesViewModels);
    }
    public async Task<ServiceResponse> GetUserFormResources(int userId)
    {
        List<UsersResource> userResources = await _userResourceRepository.GetAllAsync(userId);
        IList<Resource> resources = await _resourcesRepository.GetAllAsync();
        List<ResourcesRightsViewModel> getUserResourcesViews = new();
        foreach (UsersResource item in userResources)
        {
            ResourcesRightsViewModel getUserResourcesView = new()
            {
                ResourceId = item.ResourceId,
                ResourceName = item.Resource?.ResourceName,
                IsCreated = item.Rights.CreatePermission,
                IsDelete = item.Rights.DeletePermission,
                IsRead = item.Rights.ReadPermission,
                IsUpdate = item.Rights.UpdatePermission,
            };
            getUserResourcesViews.Add(getUserResourcesView);
        }
        foreach (Resource item in resources)
        {
            bool existed = getUserResourcesViews.Any(x => x.ResourceId == item.ID);
            if (!existed)
            {
                ResourcesRightsViewModel getUserResourcesView = new()
                {
                    ResourceId = item.ID,
                    ResourceName = item.ResourceName,
                    IsCreated = false,
                    IsDelete = false,
                    IsRead = false,
                    IsUpdate = false
                };
                getUserResourcesViews.Add(getUserResourcesView);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, getUserResourcesViews);
    }

    public async Task<ServiceResponse> GetUserResourcesV2(int userId)
    {
        List<ResourcesCategory>? resourcesCategories = await _resourceCategoryRepository.GetCotegoriesResources(userId);

        List<ResourcesCategoryViewModel>? response = new();

        foreach (ResourcesCategory resourceCategory in resourcesCategories)
        {
            ResourcesCategoryViewModel? result = resourceCategory.PrepareToViewModel();
            result.ResourcesViewModel!.AddRange(resourceCategory.Resources!.Select(resources => resources.PrepareToViewModel()).ToList());
            
            response.Add(result);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, response);
    }
}
