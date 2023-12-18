using App.Wiz.Application.Services.BranchServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.AgencyDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AgencyController : Controller
{
    private readonly IBranchServices _agencyLogic;

    public AgencyController(IBranchServices agencyLogic)
    {
        _agencyLogic = agencyLogic;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.GetAllSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _agencyLogic.GetAllAgencies());

    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.GetByIdSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> Get(int id)
    {
        return Ok(await _agencyLogic.GetSingleAgency(id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.CreateSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> Add(CreateAgencyDto createAgencyDto)
    {
        return Ok(await _agencyLogic.AddAgency(createAgencyDto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.UpdateSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> Update(UpdateAgencyDto updateAgencyDto)
    {
        return Ok(await _agencyLogic.UpdateActivestatus(updateAgencyDto));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.DeleteSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> Delete(int Id)
    {
        return Ok(await _agencyLogic.DeleteAgency(Id));
    }



    [HttpGet("GetAgenciesByCompanyId/{CompanyId}")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.GetByCompanyIdSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> GetAgenciesByCompanyId(int CompanyId)
    {
        return Ok(await _agencyLogic.GetAgenciesByCompanyId(CompanyId));
    }


    [HttpGet("GetAgenciesByUserId/{UserId}")]
    [SwaggerOperation(Summary = TagsConstants.AbAgency.GetByUserIdSummary,
            Description = TagsConstants.AbAgency.Description,
            Tags = new[] { TagsConstants.AbAgency.Tags })]
    public async Task<ActionResult> GetAgenciesByUserId(int UserId)
    {
        return Ok(await _agencyLogic.GetAgenciesByUserId(UserId));
    }
}
