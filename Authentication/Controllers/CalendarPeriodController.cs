using App.Wiz.Application.Services.CalendarPeriodServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.AccountingBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AbCalendarPeriodController : ControllerBase
{
    private readonly ICalendarPeriodServices _services;

    public AbCalendarPeriodController(ICalendarPeriodServices services)
    {
        _services = services;
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.CreateSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> Add([FromBody] CreateAccountBookCalendarPeriodDto request)
    {
        return Ok(await _services.Add(request));
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.UpdateSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> Update([FromBody] UpdateAccountBookCalendarPeriodDto request)
    {
        return Ok(await _services.Update(request));
    }

    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.GetByIdSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _services.GetById(id));
    }

    [HttpGet("GetCalenderPeriodByCompanyId/{companyId}")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.GetByCompanyIdSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> GetCalenderPeriodByCompanyId(int companyId)
    {
        return Ok(await _services.GetOnGeneralInfoId(companyId));
    }

    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.DeleteSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> Delete(int request)
    {
        return Ok(await _services.Delete(request));
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.GetAllSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> Get()
    {
        return Ok(await _services.GetAll());
    }

    [HttpPatch("ActivatePeriod")]
    [SwaggerOperation(Summary = TagsConstants.AbCalendarPeriod.ActivatePeriodSummary,
            Description = TagsConstants.AbCalendarPeriod.Description,
            Tags = new[] { TagsConstants.AbCalendarPeriod.Tags })]
    public async Task<IActionResult> ActivatePeriod([FromBody] ActivateAccountBookCalendarPeriodDto request)
    {
        return Ok(await _services.ActivatePeriod(request));
    }
}