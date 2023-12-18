using App.Wiz.Application.Services.FormulaBuilderServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormulaBuilderController : ControllerBase
{
    private readonly IFormulaBuilderService _service;

    public FormulaBuilderController(IFormulaBuilderService service)
    {
        _service = service;
    }
    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbFormulaBuilder.GetAllSummary,
            Description = TagsConstants.AbFormulaBuilder.Description,
            Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAsync());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbFormulaBuilder.GetByIdSummary,
            Description = TagsConstants.AbFormulaBuilder.Description,
            Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> Get(int Id)
    {
        return Ok(await _service.GetAsync(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbFormulaBuilder.CreateSummary,
            Description = TagsConstants.AbFormulaBuilder.Description,
            Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> Add(CreateFormulaBuilderDto create)
    {
        return Ok(await _service.AddAsync(create));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbFormulaBuilder.UpdateSummary,
            Description = TagsConstants.AbFormulaBuilder.Description,
            Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> Update(UpdateFormulaBuilderDto update)
    {
        return Ok(await _service.UpdateAsync(update));
    }

    [HttpDelete("Delete/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbFormulaBuilder.DeleteSummary,
            Description = TagsConstants.AbFormulaBuilder.Description,
            Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> Delete(int Id)
    {
        return Ok(await _service.DeleteAsync(Id));
    }
}
