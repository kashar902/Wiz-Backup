using App.Wiz.Application.Services.VehicleServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.VehicleDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _service;
    public VehicleController(IVehicleService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbVehicle.GetAllSummary,
        Description = TagsConstants.AbVehicle.Description,
        Tags = new[] { TagsConstants.AbVehicle.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllVehicles());
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbVehicle.GetByIdSummary,
        Description = TagsConstants.AbVehicle.Description,
        Tags = new[] { TagsConstants.AbVehicle.Tags })]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetVehicle(id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbVehicle.CreateSummary,
        Description = TagsConstants.AbVehicle.Description,
        Tags = new[] { TagsConstants.AbVehicle.Tags })]
    public async Task<IActionResult> Add(CreateVehicleDto dto)
    {
        return Ok(await _service.CreateVehicle(dto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbVehicle.UpdateSummary,
        Description = TagsConstants.AbVehicle.Description,
        Tags = new[] { TagsConstants.AbVehicle.Tags })]
    public async Task<IActionResult> Update(UpdateVehicleDto dto)
    {
        return Ok(await _service.UpdateVehicle(dto));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbVehicle.DeleteSummary,
        Description = TagsConstants.AbVehicle.Description,
        Tags = new[] { TagsConstants.AbVehicle.Tags })]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.DeleteVehicle(id));
    }
}
