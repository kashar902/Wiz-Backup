using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos;
using UserAssociates.Business.Logic.AssignMemberGroupBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssignMemberGroupController : Controller
	{
		public readonly IAMGLogic _assignMemberGroupLogic;
		public AssignMemberGroupController(IAMGLogic assignMemberGroupLogic)
		{
			_assignMemberGroupLogic = assignMemberGroupLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<AssignResourceGroup>>> Get()
		{
			try
			{
				var value = await _assignMemberGroupLogic.GetAllAssignMemberGroup();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult<string>> Add(AssignMemberGroupDto amgDto)
		{
			try
			{
				var result = await _assignMemberGroupLogic.AddMemberGroup(amgDto);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
