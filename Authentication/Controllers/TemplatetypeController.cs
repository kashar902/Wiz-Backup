using App.Wiz.Domain.Repositories.TemplatesRepositories;
using App.Wiz.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Wiz.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TemplateTypeController : ControllerBase
{
    private readonly ITemplateTypeRepository _repository;

    public TemplateTypeController(ITemplateTypeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("GetTemplateTypes")]
    public async Task<IActionResult> GetTemplateTypes()
    {
        IList<TemplateType> result = await _repository.GetAllAsync();

        return Ok(result.Select(x => new
        {
            TemplateTypeId = x.ID,
            TemplateTypeName = x.TypeName
        }
        ));
    }
}
