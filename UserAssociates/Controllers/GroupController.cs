using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.GroupBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupController : Controller
	{
		public readonly IGroupLogic _groupLogic;
		public GroupController(IGroupLogic groupLogic)
		{
			_groupLogic = groupLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<Groups>>> Get()
		{
			try
			{
				var value = await _groupLogic.GetAllGroups();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult<List<Groups>>> Add(Groups group)
		{
			try
			{
				var result = await _groupLogic.AddGroup(group);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
