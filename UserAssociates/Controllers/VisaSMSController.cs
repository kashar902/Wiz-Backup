using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.VisaSMSBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VisaSMSController : Controller
	{
		private readonly IVSLogic _visaSmsLogic;
		public VisaSMSController(IVSLogic visaSmsLogic)
		{
			_visaSmsLogic = visaSmsLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<VisaSMS>>> Get()
		{
			try
			{
				var value = await _visaSmsLogic.GetAllVisaSMSPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
