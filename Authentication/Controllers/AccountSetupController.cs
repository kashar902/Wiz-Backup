using App.Wiz.Application.Services.AccountSetupServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.AccountSetupDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountSetupController : ControllerBase
{
    private readonly IAccountSetupService service;
    public AccountSetupController(IAccountSetupService service)
    {
        this.service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.GetAllSummary,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await service.Get());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.GetByIdSummary,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> Get(int Id)
    {
        return Ok(await service.Get(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.CreateSummary,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> Add(CreateAccountDto model)
    {
        return Ok(await service.Add(model));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.UpdateSummary,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> Update(UpdateAccountDto model)
    {
        return Ok(await service.Update(model));
    }


    [HttpDelete("Delete/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.DeleteSummary,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> Delete(int Id)
    {
        return Ok(await service.Delete(Id));
    }

    [HttpGet("GetAccountSetupForm")]
    [SwaggerOperation(Summary = TagsConstants.AbAccountSetup.GetAccountSetupFormsData,
           Description = TagsConstants.AbAccountSetup.Description,
           Tags = new[] { TagsConstants.AbAccountSetup.Tags })]
    public async Task<IActionResult> GetAccountSetupForm()
    {
        return Ok(await service.GetAccountSetupForm());
    }
}
