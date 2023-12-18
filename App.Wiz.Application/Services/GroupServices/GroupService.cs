using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.AssignedResourceToGroupViewModels;
using App.Wiz.Common.ServiceViewModels.GroupViewModels;
using App.Wiz.Domain.Repositories.AccessRightsRepository;
using App.Wiz.Domain.Repositories.GroupRepository;
using App.Wiz.Domain.Repositories.ResourceRepository;
using App.Wiz.Domain.ServiceDtos.GroupOfCompaniesDto;
using App.Wiz.Domain.ServiceDtos.GroupsDto;
using App.Wiz.Infrastructure.Entities;
using Group = App.Wiz.Infrastructure.Entities.Group;

namespace App.Wiz.Application.Services.GroupServices;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IGroupOfCompanyRepository _groupOfCompanyRepository;
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IAccessRightsRepository _accessRightsRepository;
    private readonly IGroupDetailRepository _groupDetailRepository;
    private readonly IResourcesRepository _resourcesRepository;

    public GroupService(IGroupRepository groupRepository,
        IGroupOfCompanyRepository groupOfCompanyRepository,
        IUserGroupRepository userGroupRepository,
        IAccessRightsRepository accessRightsRepository,
        IGroupDetailRepository groupDetailRepository,
        IResourcesRepository resourcesRepository)
    {
        _resourcesRepository = resourcesRepository;
        _groupRepository = groupRepository;
        _groupOfCompanyRepository = groupOfCompanyRepository;
        _userGroupRepository = userGroupRepository;
        _accessRightsRepository = accessRightsRepository;
        _groupDetailRepository = groupDetailRepository;
    }

    #region Group and Group detail

    public async Task<ServiceResponse> AssignResourseToGroup(CreateGroupDto createGroupDto)
    {
        Group entity = await _groupRepository.AddAsync(createGroupDto.PrepareEntity());
        IList<Accessright> getAccessRights = await _accessRightsRepository.GetAllAsync();

        List<GroupDetails> groupDetails = new();

        foreach (CreateAssignResourcesToGroupDto item in createGroupDto.createAssignResourcesToGroupDtos!)
        {
            int accessRightId = getAccessRights
                .Where(m =>
                        item.IsCreated == m.CreatePermission &&
                        item.IsRead == m.ReadPermission &&
                        item.IsUpdate == m.UpdatePermission &&
                        item.IsDelete == m.DeletePermission)
                .Select(x => x.ID)
                .FirstOrDefault();

            groupDetails.Add(new()
            {
                AccessRightId = accessRightId,
                ResourceId = item.ResourceId,
                GroupId = entity.ID
            });
        }
        await _groupDetailRepository.AddAsync(groupDetails);
        return ServiceResponse.Success(Constants.AssignResoursesToGroupMessage.ResourcesAssigned);
    }
    public async Task<ServiceResponse> GetAllGroups()
    {
        List<GetAllGroupsViewModel> groupViewModel = new();

        IList<Group> groups = await _groupRepository.GetAllAsync();
        foreach (Group group in groups)
        {
            groupViewModel.Add(new GetAllGroupsViewModel
            {
                ID = group.ID,
                Description = group.Description,
                GroupName = group.GroupName,
                GroupPriority = group.GroupPriority,
            });
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, groupViewModel);
    }
    public async Task<ServiceResponse> GetGroupById(int groupId)
    {
        Group? group = await _groupRepository.GetAsync(x => x.ID == groupId);
        if (group is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        IList<GroupDetails> groupDetail = await _groupDetailRepository.GetAllByGroupIdAsync(groupId);
        List<AssignedResourceToGroupViewModel> assignedResourceToGroupViewModels = new();

        foreach (GroupDetails item in groupDetail)
        {
            assignedResourceToGroupViewModels.Add(new()
            {
                IsCreated = item.AccessRight!.CreatePermission,
                IsRead = item.AccessRight!.ReadPermission,
                IsUpdate = item.AccessRight!.UpdatePermission,
                IsDelete = item.AccessRight!.DeletePermission,
                ResourceId = item.Resource!.ID,
                ResourceName = item.Resource!.ResourceName
            });
        }
        IList<Resource> resources = await _resourcesRepository.GetAllAsync();
        foreach (var item in resources)
        {
            if (!assignedResourceToGroupViewModels.Any(x => x.ResourceId == item.ID))
            {
                assignedResourceToGroupViewModels.Add(new()
                {
                    IsCreated = false,
                    IsRead = false,
                    IsUpdate = false,
                    IsDelete = false,
                    ResourceId = item.ID,
                    ResourceName = item.ResourceName
                });
            }
        }
        GroupViewModel groupViewModel = new()
        {
            GroupName = group.GroupName,
            Description = group.Description,
            ID = group.ID,
            GroupPriority = group.GroupPriority,
            ResourceDetails = assignedResourceToGroupViewModels
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, groupViewModel);
    }
    public async Task<ServiceResponse> DeleteGroup(int id)
    {
        Group? group = await _groupRepository.GetAsync(x => x.ID == id);
        if (group is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        await _groupRepository.DeleteAsync(group);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }
    public async Task<ServiceResponse> UpdateGroup(UpdateGroupDto dto)
    {
        await _groupRepository.UpdateAsync(dto.PrepareEntity());
        IList<GroupDetails> groupDetail = await _groupDetailRepository.GetAllByGroupIdAsync(dto.GroupId);

        await _groupDetailRepository.DeleteAsync(groupDetail.ToList());
        IList<Accessright> getAccessRights = await _accessRightsRepository.GetAllAsync();

        List<GroupDetails> groupDetails = new();
        foreach (CreateAssignResourcesToGroupDto item in dto.createAssignResourcesToGroupDtos)
        {
            int accessRightId = getAccessRights
                .Where(m =>
                        item.IsCreated == m.CreatePermission &&
                        item.IsRead == m.ReadPermission &&
                        item.IsUpdate == m.UpdatePermission &&
                        item.IsDelete == m.DeletePermission)
                .Select(x => x.ID)
                .FirstOrDefault();

            groupDetails.Add(new()
            {
                AccessRightId = accessRightId,
                ResourceId = item.ResourceId,
                GroupId = dto.GroupId
            });
        }
        await _groupDetailRepository.AddAsync(groupDetails);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> GetUserGroups(int userId)
    {
        List<GetAllGroupsViewModel> getUserGroups = new();
        IList<UserGroup> userGroup = await _userGroupRepository.GetUserGroups(userId);
        IList<Group> group = await _groupRepository.GetAllAsync();
        foreach (UserGroup item in userGroup)
        {
            //Group? grp = group.Where(x => x.ID == item.GroupId).FirstOrDefault();
            GetAllGroupsViewModel getUserGroupsView = new()
            {
                ID = item.GroupId.GetValueOrDefault(),
                GroupName = item.Group?.GroupName,
                Description = item.Group?.Description,
                GroupPriority = item.Group?.GroupPriority,
                IsChecked = true
            };
            getUserGroups.Add(getUserGroupsView);
        }
        foreach (Group item in group)
        {
            bool existed = getUserGroups.Any(x => x.ID == item.ID);
            if (!existed)
            {
                GetAllGroupsViewModel getUserGroupsView = new()
                {
                    ID = item.ID,
                    GroupName = item.GroupName,
                    Description = item.Description,
                    GroupPriority = item.GroupPriority,
                    IsChecked = false,
                };
                getUserGroups.Add(getUserGroupsView);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, getUserGroups);
    }

    #endregion

    #region Group of company

    public async Task<ServiceResponse> AddGroupOfCompany(CreateGroupOfCompanyDto request)
    {
        IList<GroupOfCompany> groups = await _groupOfCompanyRepository.GetAllAsync();
        bool isDuplicate = groups.Any(item =>
                item.GroupName!.Equals(request.GroupName!.Trim(), StringComparison.OrdinalIgnoreCase));

        if (isDuplicate)
        {
            return ServiceResponse.Failure(Constants.AlreadyExist);
        }

        _ = await _groupOfCompanyRepository.AddAsync(new GroupOfCompany()
        {
            StartDate = request.StartDate,
            GroupName = request.GroupName,
            GroupDescription = request.GroupDescription,
            CurrencyId = request.CurrencyId,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            Active = request.Active,
        });
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> DeleteGroupOfCompany(int Id)
    {
        GroupOfCompany? response = await _groupOfCompanyRepository.GetAsync(x => x.GOCID == Id);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        await _groupOfCompanyRepository.DeleteAsync(response);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }
    public async Task<ServiceResponse> GetAllGroupOfCompany(bool active)
    {
        List<GroupOfCompany> response = await _groupOfCompanyRepository.GetAllAsync(active);
        List<GroupOfCompanyViewModel> viewModels = new();
        foreach (GroupOfCompany item in response)
        {
            viewModels.Add(new GroupOfCompanyViewModel()
            {
                GroupOfCompanyId = item.GOCID,
                GroupDescription = item.GroupDescription,
                GroupOfCompanyName = item.GroupName,
                StartDate = item.StartDate,
                CurrencyName = item.Currency?.CurrencyName,
                CurrencyId = item.CurrencyId,
                Active = item.Active
            });
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModels);
    }
    public async Task<ServiceResponse> GetAllGroupOfCompany()
    {
        List<GroupOfCompany> response = await _groupOfCompanyRepository.GetAllGOC();
        List<GroupOfCompanyViewModel> viewModels = new();
        foreach (GroupOfCompany item in response)
        {
            viewModels.Add(new GroupOfCompanyViewModel()
            {
                GroupOfCompanyId = item.GOCID,
                GroupDescription = item.GroupDescription,
                GroupOfCompanyName = item.GroupName,
                StartDate = item.StartDate,
                CurrencyName = item.Currency?.CurrencyName,
                CurrencyId = item.CurrencyId,
                Active = item.Active
            });
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModels);
    }

    public async Task<ServiceResponse> GetSingleGroupOfCompany(int Id)
    {
        GroupOfCompany? groupOfCompany = await _groupOfCompanyRepository.GetAsync(x => x.GOCID == Id);
        if (groupOfCompany is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        GroupOfCompanyViewModel viewModel = new()
        {
            GroupOfCompanyId = groupOfCompany.GOCID,
            CurrencyName = groupOfCompany.Currency?.CurrencyName,
            CurrencyId = groupOfCompany.CurrencyId,
            GroupDescription = groupOfCompany.GroupDescription,
            GroupOfCompanyName = groupOfCompany.GroupName,
            StartDate = groupOfCompany.StartDate,
            Active = groupOfCompany.Active
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModel);
    }
    public async Task<ServiceResponse> UpdateGroupOfCompany(UpdateGroupOfCompanyDto request)
    {
        GroupOfCompany? response = await _groupOfCompanyRepository.GetAsync(x => x.GOCID == request.GOCID);
        if (response is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        response.GroupName = request.GroupName;
        response.StartDate = request.StartDate;
        response.GroupDescription = request.GroupDescription;
        response.CurrencyId = request.CurrencyId;
        response.ModifiedBy = Global.Username;
        response.ModifiedDate = DateTime.UtcNow;
        response.Active = request.Active;
        await _groupOfCompanyRepository.UpdateAsync(response);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }

    #endregion
}
