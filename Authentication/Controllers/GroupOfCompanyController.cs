using App.Wiz.Application.Services.GroupServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.GroupOfCompaniesDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupOfCompanyController : ControllerBase
{
    private readonly IGroupService _service;

    public GroupOfCompanyController(IGroupService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.GetAllSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllGroupOfCompany());
    }

    [HttpGet("GetActive")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.GetActiveSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> GetActive()
    {
        return Ok(await _service.GetAllGroupOfCompany(true));
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.GetByIdSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int Id)
    {
        return Ok(await _service.GetSingleGroupOfCompany(Id));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.DeleteSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int Id)
    {
        return Ok(await _service.DeleteGroupOfCompany(Id));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.UpdateSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> Update(UpdateGroupOfCompanyDto request)
    {
        return Ok(await _service.UpdateGroupOfCompany(request));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbGroupOfCompany.CreateSummary,
            Description = TagsConstants.AbGroupOfCompany.Description,
            Tags = new[] { TagsConstants.AbGroupOfCompany.Tags })]
    [AllowAnonymous]
    public async Task<IActionResult> Add(CreateGroupOfCompanyDto request)
    {
        return Ok(await _service.AddGroupOfCompany(request));
    }
}
