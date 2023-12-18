using App.Wiz.Application.Services.ChargeFieldServices;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.ServiceDtos.ChargeFieldDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ChargeFieldController : ControllerBase
{
    private readonly IChargeFieldService service;
    public ChargeFieldController(IChargeFieldService service)
    {
        this.service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.GetAllSummary,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await service.Get());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.GetByIdSummary,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> Get(int Id)
    {
        return Ok(await service.Get(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.CreateSummary,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> Add(CreateChargeFieldDto model)
    {
        return Ok(await service.Add(model));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.UpdateSummary,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> Update(UpdateChargeFieldDto model)
    {
        return Ok(await service.Update(model));
    }


    [HttpDelete("Delete/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.DeleteSummary,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> Delete(int Id)
    {
        return Ok(await service.Delete(Id));

    }

    [HttpGet("GetChargeFieldFormData")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.GetChargeFieldFormData,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbChargeField.Tags })]
    public async Task<IActionResult> GetChargeFieldFormData()
    {
        return Ok(await service.GetChargeFieldFormData());
    }

    [HttpGet("GetChargeField")]
    [SwaggerOperation(Summary = TagsConstants.AbChargeField.GetChargeFieldDropdowndata,
           Description = TagsConstants.AbChargeField.Description,
           Tags = new[] { TagsConstants.AbFormulaBuilder.Tags })]
    public async Task<IActionResult> GetChargeField()
    {
        return Ok(await service.GetChargeField());
    }
}
