using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.UserBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserLogic _userLogic;
		public UserController(IUserLogic userLogic)
		{
			_userLogic = userLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<User>>> Get()
		{
			try
			{
				var value = await _userLogic.GetAllUser();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
