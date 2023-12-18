using App.Wiz.Application.Services.FlightClassServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.FlightClassCategoryDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightClassCategoryController : ControllerBase
{
    private readonly IFlightClassService _service;
    public FlightClassCategoryController(IFlightClassService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClassCategory.GetAllSummary,
            Description = TagsConstants.AbFlightClassCategory.Description,
            Tags = new[] { TagsConstants.AbFlightClassCategory.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _service.GetFlightClassCategories());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClassCategory.GetAllSummary,
            Description = TagsConstants.AbFlightClassCategory.Description,
            Tags = new[] { TagsConstants.AbFlightClassCategory.Tags })]
    public async Task<ActionResult> Get(int Id)
    {
        return Ok(await _service.GetFlightClassCategoryById(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClassCategory.GetAllSummary,
            Description = TagsConstants.AbFlightClassCategory.Description,
            Tags = new[] { TagsConstants.AbFlightClassCategory.Tags })]
    public async Task<ActionResult> Add([FromBody] CreateFlightClassCategoryDto model)
    {
        return Ok(await _service.Create(model));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClassCategory.GetAllSummary,
            Description = TagsConstants.AbFlightClassCategory.Description,
            Tags = new[] { TagsConstants.AbFlightClassCategory.Tags })]
    public async Task<ActionResult> Update([FromBody] UpdateFlightClassCategoryDto model)
    {
        return Ok(await _service.Update(model));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClassCategory.GetAllSummary,
            Description = TagsConstants.AbFlightClassCategory.Description,
            Tags = new[] { TagsConstants.AbFlightClassCategory.Tags })]
    public async Task<ActionResult> Delete(int Id)
    {
        return Ok(await _service.DeleteFlightClassCategory(Id));
    }
}
