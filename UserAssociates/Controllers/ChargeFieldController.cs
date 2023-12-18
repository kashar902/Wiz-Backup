using Commons.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.ChargeFieldDto;
using UserAssociates.Business.Logic.ChargeFieldBusinessLogic;

namespace UserAssociates.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ChargeFieldController : ControllerBase
{
	private readonly IChargeFieldBusinessLogic _chargeFieldLogic;
	public ChargeFieldController(IChargeFieldBusinessLogic chargeFieldLogic)
	{
		_chargeFieldLogic = chargeFieldLogic;
	}

	[HttpGet("Get")]
	public async Task<IActionResult> Get()
	{
		try
		{
			return Ok(await _chargeFieldLogic.GetAll());
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpGet("Get/{id}")]
	public async Task<IActionResult> Get(int id)
	{
		try
		{
			var checkRecord = await _chargeFieldLogic.GetById(id);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpDelete("Delete")]
	[Authorize]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{

			var checkRecord = await _chargeFieldLogic.Delete(id);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpPost("Add")]
	public async Task<IActionResult> Add(CreateChargeFieldDto dto)
	{
		try
		{
			return Ok(await _chargeFieldLogic.Create(dto));
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpPut("Update")]
	public async Task<IActionResult> Update(UpdateChargeFieldDto dto)
	{
		try
		{
			var checkRecord = await _chargeFieldLogic.Update(dto);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
