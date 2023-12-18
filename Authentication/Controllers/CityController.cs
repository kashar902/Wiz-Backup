using App.Wiz.Application.Services.CityServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Common.ServiceViewModels.CityViewModels;
using App.Wiz.Domain.ServiceDtos.CityDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityLogic;
    public CityController(ICityService cityLogic)
    {
        _cityLogic = cityLogic;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbCity.GetAllSummary,
        Description = TagsConstants.AbCity.Description,
        Tags = new[] { TagsConstants.AbCity.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _cityLogic.GetAllCities());
    }

    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbCity.GetByIdSummary,
        Description = TagsConstants.AbCity.Description,
        Tags = new[] { TagsConstants.AbCity.Tags })]
    public async Task<ActionResult> Get(int Id)
    {
        return Ok(await _cityLogic.GetCity(Id));
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbCity.CreateSummary,
        Description = TagsConstants.AbCity.Description,
        Tags = new[] { TagsConstants.AbCity.Tags })]
    public async Task<ActionResult> Add([FromBody] CreateCityDto model)
    {
        return Ok(await _cityLogic.CreateCity(model));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbCity.UpdateSummary,
        Description = TagsConstants.AbCity.Description,
        Tags = new[] { TagsConstants.AbCity.Tags })]
    public async Task<ActionResult> Update([FromBody] UpdateCityDto model)
    {
        return Ok(await _cityLogic.UpdateCity(model));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbCity.DeleteSummary,
        Description = TagsConstants.AbCity.Description,
        Tags = new[] { TagsConstants.AbCity.Tags })]
    public async Task<ActionResult> Delete(int Id)
    {
        return Ok(await _cityLogic.DeleteCity(Id));
    }
}
