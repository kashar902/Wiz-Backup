using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystDefaultBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystDefaultController : Controller
	{
		private readonly ICDLogic _catalystDefault;

		public CatalystDefaultController(ICDLogic catalystDefault)
		{
			_catalystDefault = catalystDefault;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystDefault>>> Get()
		{
			try
			{
				var value = await _catalystDefault.GetAllCatalystDefaultUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
