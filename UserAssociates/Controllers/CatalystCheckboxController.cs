using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystCheckboxBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystCheckboxController : Controller
	{
		private readonly ICCLogic _catalystCheckboxLogic;

		public CatalystCheckboxController(ICCLogic catalystCheckboxLogic)
		{
			_catalystCheckboxLogic = catalystCheckboxLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystCheckbox>>> Get()
		{
			try
			{
				var value = await _catalystCheckboxLogic.GetAllCatalystCheckboxUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
