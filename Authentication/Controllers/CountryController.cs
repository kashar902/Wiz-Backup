using App.Wiz.Application.Services.CountryServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.CountryDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _service;
    public CountryController(ICountryService service)
    {
        _service = service;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbCountry.GetAllSummary,
            Description = TagsConstants.AbCountry.Description,
            Tags = new[] { TagsConstants.AbCountry.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _service.GetAllCountries());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbCountry.GetByIdSummary,
            Description = TagsConstants.AbCountry.Description,
            Tags = new[] { TagsConstants.AbCountry.Tags })]
    public async Task<ActionResult> Get(int Id)
    {
        return Ok(await _service.GetCountry(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbCountry.CreateSummary,
            Description = TagsConstants.AbCountry.Description,
            Tags = new[] { TagsConstants.AbCountry.Tags })]
    public async Task<ActionResult> Add([FromBody] CreateCountryDto model)
    {
        return Ok(await _service.AddAsync(model));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbCountry.UpdateSummary,
            Description = TagsConstants.AbCountry.Description,
            Tags = new[] { TagsConstants.AbCountry.Tags })]
    public async Task<ActionResult> Update([FromBody] UpdateCountryDto model)
    {
        return Ok(await _service.UpdateAsync(model));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbCountry.DeleteSummary,
            Description = TagsConstants.AbCountry.Description,
            Tags = new[] { TagsConstants.AbCountry.Tags })]
    public async Task<ActionResult> Delete(int Id)
    {
        return Ok(await _service.DeleteAsync(Id));
    }

}
