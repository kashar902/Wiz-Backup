using App.Wiz.Application.Services.ResourceServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.ResourceDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourceController : Controller
{
    private readonly IResourcesService _resourceService;
    public ResourceController(IResourcesService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbResource.GetAllSummary,
        Description = TagsConstants.AbResource.Description,
        Tags = new[] { TagsConstants.AbResource.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _resourceService.GetAllResources());
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbResource.CreateSummary,
        Description = TagsConstants.AbResource.Description,
        Tags = new[] { TagsConstants.AbResource.Tags })]
    public async Task<ActionResult> Add(CreateResourceDto resourceData)
    {
        return Ok(await _resourceService.AddResource(resourceData));
    }

    [HttpGet("GetResourcesByUserId/{UserId}")]
    [SwaggerOperation(Summary = TagsConstants.AbResource.GetByUserIdSummary,
        Description = TagsConstants.AbResource.Description,
        Tags = new[] { TagsConstants.AbResource.Tags })]
    public async Task<ActionResult> GetResourcesByUserId(int UserId)
    {
        return Ok(await _resourceService.GetUserFormResources(UserId));
    }
}
