using Commons.Messages;
using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos.CityTaxDto;
using UserAssociates.Business.Logic.CityBusinessLogic;
using UserAssociates.Business.Viewmodels;

namespace UserAssociates.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CityTaxController : ControllerBase
	{
		private readonly ICityTaxBusinessLogic _cityTaxBusinessLogic;
		public CityTaxController(ICityTaxBusinessLogic cityTaxBusinessLogic)
		{
			_cityTaxBusinessLogic = cityTaxBusinessLogic;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			try
			{
				return Ok(await _cityTaxBusinessLogic.GetAllCityTaxes());
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
				CityTaxViewModel? checkRecord = await _cityTaxBusinessLogic.GetCityTax(id);
				return (checkRecord is null)
					? BadRequest(Constants.NotFound) : Ok(checkRecord);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost("Add")]
		public async Task<IActionResult> Add(CreateCityTaxDto dto)
		{
			try
			{
				return Ok(await _cityTaxBusinessLogic.CreateCityTax(dto));
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut("Update")]
		public async Task<IActionResult> Update(UpdateCityTaxDto dto)
		{
			try
			{
				string? checkrecord = await _cityTaxBusinessLogic.UpdateCityTax(dto);
				return (checkrecord is null)
					? BadRequest(Constants.NotFound) : Ok(checkrecord);
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
				string? checkRecord = await _cityTaxBusinessLogic.DeleteCityTax(id);
				return (checkRecord is null)
					? BadRequest(Constants.NotFound) : Ok(checkRecord);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
