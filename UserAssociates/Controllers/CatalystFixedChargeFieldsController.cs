using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystFixedChargeFieldsBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystFixedChargeFieldsController : Controller
	{
		private readonly ICFCFLogic _catalystFixedChargeFieldsLogic;

		public CatalystFixedChargeFieldsController(ICFCFLogic catalystFixedChargeFieldsLogic)
		{
			_catalystFixedChargeFieldsLogic = catalystFixedChargeFieldsLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystFixedChargeFields>>> Get()
		{
			try
			{
				var value = await _catalystFixedChargeFieldsLogic.GetAllCatalystFixedChargeFieldsUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
