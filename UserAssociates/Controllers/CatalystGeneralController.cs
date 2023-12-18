using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.CatalystGeneralBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalystGeneralController : Controller
	{
		private readonly ICGLogic _catalystGeneralLogic;

		public CatalystGeneralController(ICGLogic catalystGeneralLogic)
		{
			_catalystGeneralLogic = catalystGeneralLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<CatalystGeneral>>> Get()
		{
			try
			{
				var value = await _catalystGeneralLogic.GetAllCatalystGeneralUserPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
