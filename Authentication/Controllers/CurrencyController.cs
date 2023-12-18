using App.Wiz.Application.Services.CurrencyServices;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.CurrencyDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyServices _services;

    public CurrencyController(ICurrencyServices currencyLogic)
    {
        _services = currencyLogic;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.GetAllSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<IActionResult> Get()
    {
        ServiceResponse value = await _services.GetAllCurrencies(false);
        return Ok(value);
    }
    [HttpGet("GetActive")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.GetActiveSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<IActionResult> GetActive()
    {
        ServiceResponse value = await _services.GetAllCurrencies(true);
        return Ok(value);
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.GetByIdSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<ActionResult> Get(int Id)
    {
        ServiceResponse value = await _services.GetCurrency(Id);
        return Ok(value);
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.CreateSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<ActionResult> Add([FromBody] CreateCurrencyDto model)
    {
        ServiceResponse value = await _services.CreateCurrency(model);
        return Ok(value);
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.UpdateSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<ActionResult> Update([FromBody] UpdateCurrencyDto model)
    {
        ServiceResponse value = await _services.UpdateCurrency(model);
        return Ok(value);
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbCurrency.DeleteSummary,
            Description = TagsConstants.AbCurrency.Description,
            Tags = new[] { TagsConstants.AbCurrency.Tags })]
    public async Task<ActionResult> Delete(int Id)
    {
        ServiceResponse value = await _services.DeleteCurrency(Id);
        return Ok(value);
    }
}
