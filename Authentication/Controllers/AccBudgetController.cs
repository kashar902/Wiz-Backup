using App.Wiz.Application.Services.SubsidaryAccountServices;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccBudgetController : ControllerBase
{
    private readonly ISubsidaryAccountService _logic;

    public AccBudgetController(ISubsidaryAccountService logic)
    {
        _logic = logic;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AccBudget.GetAllSummary,
            Description = TagsConstants.AccBudget.Description,
            Tags = new[] { TagsConstants.AccBudget.Tags })]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _logic.GetAllBudgetPeriod());
    }
    [HttpGet("Get/{id}")]
    [SwaggerOperation(Summary = TagsConstants.AccBudget.GetByIdSummary,
            Description = TagsConstants.AccBudget.Description,
            Tags = new[] { TagsConstants.AccBudget.Tags })]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _logic.GetBudgetPeriod(id));
    }
}
