using App.Wiz.Application.Services.SubsidaryAccountServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Common.ServiceViewModels.SubsidaryViewModels;
using App.Wiz.Domain.ServiceDtos.SubsidiaryAccountDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubsidaryAccountController : ControllerBase
{
    private readonly ISubsidaryAccountService _logic;

    public SubsidaryAccountController(ISubsidaryAccountService logic)
    {
        _logic = logic;
    }


    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbSubsidaryAccount.GetAllSummary,
            Description = TagsConstants.AbSubsidaryAccount.Description,
            Tags = new[] { TagsConstants.AbSubsidaryAccount.Tags })]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _logic.GetAll());
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbSubsidaryAccount.GetByIdSummary,
            Description = TagsConstants.AbSubsidaryAccount.Description,
            Tags = new[] { TagsConstants.AbSubsidaryAccount.Tags })]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _logic.Get(id));
    }

    [HttpDelete("Delete/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbSubsidaryAccount.DeleteSummary,
            Description = TagsConstants.AbSubsidaryAccount.Description,
            Tags = new[] { TagsConstants.AbSubsidaryAccount.Tags })]
    public async Task<IActionResult> Delete(Guid Id)
    {
        return Ok(await _logic.DeleteAsync(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbSubsidaryAccount.CreateSummary,
            Description = TagsConstants.AbSubsidaryAccount.Description,
            Tags = new[] { TagsConstants.AbSubsidaryAccount.Tags })]
    public async Task<IActionResult> Add(CreateSubsidiaryAccountDto dto)
    {
        return Ok(await _logic.AddAsync(dto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbSubsidaryAccount.UpdateSummary,
            Description = TagsConstants.AbSubsidaryAccount.Description,
            Tags = new[] { TagsConstants.AbSubsidaryAccount.Tags })]
    public async Task<IActionResult> Update(UpdateSubsidiaryAccountDto dto)
    {
        return Ok(await _logic.UpdateAsync(dto));
    }
}
