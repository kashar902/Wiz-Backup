using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.HotelInventoryBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelInventoryController : Controller
	{
		private readonly IHILogic _hotelInventoryLogic;
		public HotelInventoryController(IHILogic hotelInventoryLogic)
		{
			_hotelInventoryLogic = hotelInventoryLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<HotelInventory>>> Get()
		{
			try
			{
				var value = await _hotelInventoryLogic.GetAllHotelInventoryPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
