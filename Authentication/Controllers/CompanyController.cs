using App.Wiz.Application.Services.CompanyServices;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.CompanyDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : Controller
{
    private readonly ICompanyServices _companyLogic;
    public CompanyController(ICompanyServices companyLogic)
    {
        _companyLogic = companyLogic;
    }

    [HttpGet("Get")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.GetAllSummary,
            Description = TagsConstants.AbCompany.Description,
            Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<ActionResult> Get()
    {
        return Ok(await _companyLogic.GetAllCompanies(false));
    }

    [HttpGet("GetActive")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.GetActiveSummary,
        Description = TagsConstants.AbCompany.Description,
        Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<ActionResult> GetActive()
    {
            ServiceResponse value = await _companyLogic.GetAllCompanies(true);
            return Ok(value);
    }

    [HttpPost("Add")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.CreateSummary,
        Description = TagsConstants.AbCompany.Description,
        Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<ActionResult> Add([FromBody] CreateCompanyDto createCompanyDto)
    {
            ServiceResponse value = await _companyLogic.CreateCompany(createCompanyDto);
            return Ok(value);
    }

    [HttpPut("Update")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.UpdateSummary,
            Description = TagsConstants.AbCompany.Description,
            Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<ActionResult> Update([FromBody] UpdateCompanyDto updateCompanyDto)
    {
            ServiceResponse value = await _companyLogic.UpdateCompany(updateCompanyDto);
            return Ok(value);
    }


    [HttpGet("Get/{Id}")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.GetByIdSummary,
            Description = TagsConstants.AbCompany.Description,
            Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<ActionResult> Get(int Id)
    {
            ServiceResponse value = await _companyLogic.GetSingleCompany(Id);
            return Ok(value);
    }


    [HttpDelete("Delete")]
    [SwaggerOperation(Summary = TagsConstants.AbCompany.DeleteSummary,
            Description = TagsConstants.AbCompany.Description,
            Tags = new[] { TagsConstants.AbCompany.Tags })]
    public async Task<IActionResult> Delete(int id)
    {
            return Ok(await _companyLogic.DeleteCompany(id));
    }
}
