using App.Wiz.Application.Services.FlightClassServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.FlightClassDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightClassController : ControllerBase
{
    private readonly IFlightClassService _service;
    public FlightClassController(IFlightClassService service)
    {
        _service = service;
    }
    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClass.GetAllSummary,
            Description = TagsConstants.AbFlightClass.Description,
            Tags = new[] { TagsConstants.AbFlightClass.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.Get());
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClass.GetByIdSummary,
            Description = TagsConstants.AbFlightClass.Description,
            Tags = new[] { TagsConstants.AbFlightClass.Tags })]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClass.CreateSummary,
            Description = TagsConstants.AbFlightClass.Description,
            Tags = new[] { TagsConstants.AbFlightClass.Tags })]
    public async Task<IActionResult> Add(CreateFlightClassDto dto)
    {
        return Ok(await _service.Create(dto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClass.UpdateSummary,
            Description = TagsConstants.AbFlightClass.Description,
            Tags = new[] { TagsConstants.AbFlightClass.Tags })]
    public async Task<IActionResult> Update(UpdateFlightClassDto dto)
    {
        return Ok(await _service.Update(dto));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbFlightClass.DeleteSummary,
            Description = TagsConstants.AbFlightClass.Description,
            Tags = new[] { TagsConstants.AbFlightClass.Tags })]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }
}
