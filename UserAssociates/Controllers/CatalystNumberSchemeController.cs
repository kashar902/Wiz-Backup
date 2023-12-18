using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystNumberSchemeBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystNumberSchemeController : Controller
	{
		private readonly ICNSLogic _catalystNumberSchemeLogic;

		public CatalystNumberSchemeController(ICNSLogic catalystNumberSchemeLogic)
		{
			_catalystNumberSchemeLogic = catalystNumberSchemeLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystNumberScheme>>> Get()
		{
			try
			{
				var value = await _catalystNumberSchemeLogic.GetAllCatalystNumberSchemeUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
