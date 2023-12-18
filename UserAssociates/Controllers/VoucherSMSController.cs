using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.VoucherBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VoucherSMSController : Controller
	{

		private IVoucherSLogic _voucherSmsLogic;
		public VoucherSMSController(IVoucherSLogic voucherSmsLogic)
		{
			_voucherSmsLogic = voucherSmsLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<VoucherSMS>>> Get()
		{
			try
			{
				var value = await _voucherSmsLogic.GetAllVoucherSMSPref();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
