using App.Wiz.Application.Services.ControlAccountServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.ControlAccountDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControlAccountController : ControllerBase
{
    private readonly IControlAccountService _controlAccountService;
    public ControlAccountController(IControlAccountService controlAccountService)
    {
        _controlAccountService = controlAccountService;
    }


    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.GetAllSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _controlAccountService.Get());
    }

    [HttpGet("GetById")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.GetByIdSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> GetById(string Id, bool isControlAccount)
    {
        return Ok(await _controlAccountService.GetById(Id, isControlAccount));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.CreateSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> Add(CreateControlAccountDto dto)
    {
        return Ok(await _controlAccountService.AddAsync(dto));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.UpdateSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> Update(UpdateControlAccountDto dto)
    {
        return Ok(await _controlAccountService.UpdateAsync(dto));
    }

    [HttpDelete("Delete/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.DeleteSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> Delete(string Id)
    {
        return Ok(await _controlAccountService.DeleteAsync(Id));
    }

    [HttpPost("ToggleActiveStatus")]
    [SwaggerOperation(Summary = TagsConstants.AbControlAccount.GetAllSummary,
            Description = TagsConstants.AbControlAccount.Description,
            Tags = new[] { TagsConstants.AbControlAccount.Tags })]
    public async Task<IActionResult> ToggleActiveStatus(string controlAccountId)
    {
        return Ok(await _controlAccountService.ToggleActiveStatus(controlAccountId));
    }
}
