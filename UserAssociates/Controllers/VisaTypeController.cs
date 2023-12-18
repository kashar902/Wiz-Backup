using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.VisaTypeDto;
using UserAssociates.Business.Logic.VisaTypeBusinessLogic;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class VisaTypeController : ControllerBase
	{
		private readonly IVisaTypeLogic _visaTypeLogic;
		public VisaTypeController(IVisaTypeLogic visaTypeLogic)
		{
			_visaTypeLogic = visaTypeLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<VisaType>>> Get()
		{
			try
			{
				List<VisaType> value = await _visaTypeLogic.GetAllVisaTypes();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult> Add([FromBody] CreateVisaTypeDto model)
		{
			try
			{
				string value = await _visaTypeLogic.CreateVisaType(model);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("Update")]
		public async Task<ActionResult> Update([FromBody] UpdateVisaTypeDto model)
		{
			try
			{
				string value = await _visaTypeLogic.UpdateVisaType(model);
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
				VisaTypeViewModel? value = await _visaTypeLogic.GetVisaType(Id);
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
				string value = await _visaTypeLogic.DeleteVisaType(Id);
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
