using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.GeneralBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GeneralUserPreferenceController : Controller
	{
		private readonly IGLogic _generalLogic;
		public GeneralUserPreferenceController(IGLogic generalLogic)
		{
			_generalLogic = generalLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<General>>> Get()
		{
			try
			{
				var value = await _generalLogic.GetAllGeneralUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
