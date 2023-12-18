using App.Wiz.Application.Services.SuperTypeServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperTypeController : ControllerBase
{
    private readonly ISupertTypeService _service;

    public SuperTypeController(ISupertTypeService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbSuperType.GetAllSummary,
            Description = TagsConstants.AbSuperType.Description,
            Tags = new[] { TagsConstants.AbSuperType.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}
