using Commons.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.FormulaBuilder;
using UserAssociates.Business.Logic.FormulaBuilderBusinessLogic;

namespace UserAssociates.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class FormulaBuilderController : ControllerBase
{
	private readonly IFormulaBuilderBusinessLogic _formulaBuilderLogic;
	public FormulaBuilderController(IFormulaBuilderBusinessLogic formulaBuilderLogic)
	{
		_formulaBuilderLogic = formulaBuilderLogic;
	}

	[HttpGet("Get")]
	public async Task<IActionResult> Get()
	{
		try
		{
			return Ok(await _formulaBuilderLogic.GetAll());
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
			var checkRecord = await _formulaBuilderLogic.GetById(id);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpPost("Add")]
	public async Task<IActionResult> Add(CreateFormulaBuilderDto dto)
	{
		try
		{
			return Ok(await _formulaBuilderLogic.Create(dto));
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpPut("Update")]
	public async Task<IActionResult> Update(UpdateFormulaBuilderDto dto)
	{
		try
		{
			var checkRecord = await _formulaBuilderLogic.Update(dto);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}

	[HttpDelete("Delete")]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			var checkRecord = await _formulaBuilderLogic.Delete(id);
			return (checkRecord is null)
				? BadRequest(Constants.NotFound) : Ok(checkRecord);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
