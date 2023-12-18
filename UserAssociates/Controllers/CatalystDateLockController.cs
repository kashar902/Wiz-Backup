using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystDateLockBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystDateLockController : Controller
	{
		private readonly ICDLLogic _catalystDateLockLogic;

		public CatalystDateLockController(ICDLLogic catalystDateLockLogic)
		{
			_catalystDateLockLogic = catalystDateLockLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystDateLock>>> Get()
		{
			try
			{
				var value = await _catalystDateLockLogic.GetAllCatalystDateLockUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
