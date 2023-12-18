using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.VisitTypeDto;
using UserAssociates.Business.Logic.VisitTypeBusinessLogic;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class VisitTypeController : ControllerBase
	{
		private readonly IVisitTypeLogic _visitTypeLogic;
		public VisitTypeController(IVisitTypeLogic visitTypeLogic)
		{
			_visitTypeLogic = visitTypeLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<VisitType>>> Get()
		{
			try
			{
				List<VisitType> value = await _visitTypeLogic.GetAllVisitTypes();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult> Add([FromBody] CreateVisitTypeDto model)
		{
			try
			{
				string value = await _visitTypeLogic.CreateVisitType(model);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("Update")]
		public async Task<ActionResult> Update([FromBody] UpdateVisitTypeDto model)
		{
			try
			{
				string value = await _visitTypeLogic.UpdateVisitType(model);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("Get/{Id}")]
		public async Task<ActionResult> Get(int Id)
		{
			try
			{
				VisitTypeViewModel? value = await _visitTypeLogic.GetVisitType(Id);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("Delete")]
		public async Task<ActionResult> Delete(int Id)
		{
			try
			{
				string value = await _visitTypeLogic.DeleteVisitType(Id);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
