using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Dtos;
using UserAssociates.Business.Logic.AssignResourceGroupBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssignResourceGroupController : Controller
	{
		public readonly IARGLogic _assignResourceGroupLogic;
		public AssignResourceGroupController(IARGLogic assignResourceGroupLogic)
		{
			_assignResourceGroupLogic = assignResourceGroupLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<AssignResourceGroup>>> Get()
		{
			try
			{
				var value = await _assignResourceGroupLogic.GetAllAssignResourceGroup();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult<string>> Add(AssignResourceGroupDto argDto)
		{
			try
			{
				var result = await _assignResourceGroupLogic.AddResourceGroup(argDto);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
