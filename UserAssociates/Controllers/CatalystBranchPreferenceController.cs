using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystBranchPreferenceBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystBranchPreferenceController : Controller
	{
		private readonly ICBPLogic _catalystBranchPrefLogic;
		public CatalystBranchPreferenceController(ICBPLogic catalystBranchPrefLogic)
		{
			_catalystBranchPrefLogic = catalystBranchPrefLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystBranchPreferences>>> Get()
		{
			try
			{
				var value = await _catalystBranchPrefLogic.GetAllCatalystBranchPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
