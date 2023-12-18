using App.Wiz.Application.Services.RoomServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.RoomsDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _service;

    public RoomController(IRoomService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbRoom.GetAllSummary,
            Description = TagsConstants.AbRoom.Description,
            Tags = new[] { TagsConstants.AbRoom.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.Get());
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbRoom.GetByIdSummary,
            Description = TagsConstants.AbRoom.Description,
            Tags = new[] { TagsConstants.AbRoom.Tags })]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbRoom.CreateSummary,
            Description = TagsConstants.AbRoom.Description,
            Tags = new[] { TagsConstants.AbRoom.Tags })]
    public async Task<IActionResult> Add(CreateRoomDto dto)
    {
        return Ok(await _service.Create(dto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbRoom.UpdateSummary,
            Description = TagsConstants.AbRoom.Description,
            Tags = new[] { TagsConstants.AbRoom.Tags })]
    public async Task<IActionResult> Update(UpdateRoomDto dto)
    {
        return Ok(await _service.Update(dto));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbRoom.DeleteSummary,
            Description = TagsConstants.AbRoom.Description,
            Tags = new[] { TagsConstants.AbRoom.Tags })]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }
}
