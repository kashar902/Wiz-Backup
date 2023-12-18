using App.Wiz.Application.Services.CreditTermServices;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain.ServiceDtos.CreditTermDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace App.Wiz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditTermController : ControllerBase
    {
        private readonly ICreditTermService _service;
        public CreditTermController(ICreditTermService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        [SwaggerOperation(Summary = TagsConstants.AbCreditTerm.GetAllSummary,
            Description = TagsConstants.AbCreditTerm.Description,
            Tags = new[] { TagsConstants.AbCreditTerm.Tags })]
        public async Task<ActionResult> Get()
        {
            return Ok(await _service.GetAllCreditTerms());
        }

        [HttpGet("Get/{Id}")]
        [SwaggerOperation(Summary = TagsConstants.AbCreditTerm.GetByIdSummary,
            Description = TagsConstants.AbCreditTerm.Description,
            Tags = new[] { TagsConstants.AbCreditTerm.Tags })]
        public async Task<ActionResult> Get(int Id)
        {
            return Ok(await _service.GetCreditTerm(Id));
        }

        [HttpPost("Add")]
        [SwaggerOperation(Summary = TagsConstants.AbCreditTerm.CreateSummary,
            Description = TagsConstants.AbCreditTerm.Description,
            Tags = new[] { TagsConstants.AbCreditTerm.Tags })]
        public async Task<ActionResult> Add([FromBody] CreateCreditTermDto model)
        {
            return Ok(await _service.CreateCreditTerm(model));
        }

        [HttpPut("Update")]
        [SwaggerOperation(Summary = TagsConstants.AbCreditTerm.UpdateSummary,
            Description = TagsConstants.AbCreditTerm.Description,
            Tags = new[] { TagsConstants.AbCreditTerm.Tags })]
        public async Task<ActionResult> Update([FromBody] UpdateCreditTermDto model)
        {
            ServiceResponse value = await _service.UpdateCreditTerm(model);
            return Ok(value);
        }

        [HttpDelete("Delete")]
        [SwaggerOperation(Summary = TagsConstants.AbCreditTerm.DeleteSummary,
            Description = TagsConstants.AbCreditTerm.Description,
            Tags = new[] { TagsConstants.AbCreditTerm.Tags })]
        public async Task<ActionResult> Delete(int Id)
        {
            return Ok(await _service.DeleteCreditTerm(Id));
        }
    }
}
