using App.Wiz.Application.Services.GroupServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.GroupsDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : Controller
{
    private readonly IGroupService _service;

    public GroupController(IGroupService service)
    {
        _service = service;
    }


    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.GetAllSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _service.GetAllGroups());
    }

    [HttpGet("Get/{ID}")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.GetByIdSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<ActionResult> Get(int ID)
    {
        return Ok(await _service.GetGroupById(ID));
    }

    [HttpPost("AssignResourceToGroup")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.AssignResourceToGroupSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<IActionResult> AssignResourceToGroup(CreateGroupDto createGroupDto)
    {
        return Ok(await _service.AssignResourseToGroup(createGroupDto));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.DeleteSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteGroup(id));
    }

    [HttpPost("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.UpdateSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<IActionResult> Update(UpdateGroupDto dto)
    {
        return Ok(await _service.UpdateGroup(dto));
    }

    [HttpGet("GetGroupsByUserId/{UserId}")]
    [SwaggerOperation(Summary = TagsConstants.AbGroup.GetByUserIdSummary,
            Description = TagsConstants.AbGroup.Description,
            Tags = new[] { TagsConstants.AbGroup.Tags })]
    public async Task<ActionResult> GetGroupsByUserId(int UserId)
    {
            return Ok(await _service.GetUserGroups(UserId));
    }

    //[HttpPost("AddGroup")]
    //public async Task<ActionResult<List<Group>>> AddGroup([FromBody] Group groupData)
    //{

    //    try
    //    {
    //        return Ok(await _logic.AddAgency(groupData));
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //[HttpPost("AddGroupDetail")]
    //public async Task<ActionResult<List<Group>>> AddGroupDetail([FromBody] GroupResourceDto groupDetailData)
    //{
    //    try
    //    {
    //        return Ok(await _logic.AddGroupDetail(groupDetailData));
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}