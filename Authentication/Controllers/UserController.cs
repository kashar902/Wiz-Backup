using App.Wiz.Application.Services.ResourceServices;
using App.Wiz.Application.Services.UserServices;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _service;
    private readonly IResourcesService _resourceService;
    public UserController(IUserService service, IResourcesService resourceService)
    {
        _service = service;
        _resourceService = resourceService;
    }
    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.GetAllSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _service.GetAllUsers());
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.GetByIdSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> Get(int id)
    {
        return Ok(await _service.GetSingleUser(id));
    }

    [HttpGet("ChangeUserStatus/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.ChangeUserStatusSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> ChangeUserStatus(int id)
    {
        return Ok(await _service.ChangeUserStatus(id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.ChangeUserStatusSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> Add(CreateUserWithBranchListDto users)
    {
        return Ok(await _service.CreateUser(users));
    }

    [HttpPost("AddUserResource")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.ChangeUserStatusSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> AddUserResource([FromBody] UserResourceDto userResource)
    {
        return Ok(await _service.AddUserResource(userResource));
    }

    [HttpPost("AddUserGroup")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.ChangeUserStatusSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> AddUserGroup(UserGroupDto model)
    {
        return Ok(await _service.AssignGroupsToUser(model));
    }
    [SwaggerOperation(Summary = TagsConstants.AbUser.UpdateSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    [HttpPut("Update")]
    public async Task<ActionResult<string>> Update(UserDto user)
    {
        return Ok(await _service.UpdateUser(user));
    }

    [HttpPost("AssignBranches")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.AssignBranchesSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<ActionResult> AssignBranches(AssignBranchDto model)
    {
        return Ok(await _service.AssignBranches(model));
    }

    [HttpGet("GetUserResource")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.GetUserResourceSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<IActionResult> GetUserResource()
    {
        int userId = Global.UserId;
        return Ok(await _resourceService.GetUserResources(userId)); ;
    }

    [HttpGet("V2/GetUserResource")]
    public async Task<IActionResult> GetUserResourceV2()
    {
        int userId = 1;// Global.UserId;
        return Ok(await _resourceService.GetUserResourcesV2(userId)); ;
    }

    [HttpPost("GetRights")]
    [SwaggerOperation(Summary = TagsConstants.AbUser.GetRightsSummary,
            Description = TagsConstants.AbUser.Description,
            Tags = new[] { TagsConstants.AbUser.Tags })]
    public async Task<IActionResult> GetRightsDataAsync(GetRightsDto dto)
    {
        dto.UserId = Global.UserId;
        return Ok(await _resourceService.GetRightsDataOnPath(dto));
    }

    [HttpGet("GetProfile")]
    public async Task<IActionResult> GetProfile()
    {
        return Ok(await _service.GetProfile());
    }

    [HttpPost("SetProfile")]
    public async Task<IActionResult> SetProfile(UpdateUserProfileDto dto)
    {
        return Ok(await _service.SetProfile(dto));
    }

    [HttpGet("GetUserCompanies")]
    public async Task<IActionResult> GetUserCompanies()
    {
        return Ok(await _service.GetUserCompanies());
    }
}

