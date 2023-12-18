using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.ResourceBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceController : Controller
	{
		public readonly IResLogic _resourceLogic;
		public ResourceController(IResLogic resourceLogic)
		{
			_resourceLogic = resourceLogic;
		}

		[HttpGet("Get")]
		public async Task<ActionResult<List<Resources>>> Get()
		{
			try
			{
				var value = await _resourceLogic.GetAllResources();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Add")]
		public async Task<ActionResult<List<Resources>>> Add(Resources resource)
		{
			try
			{
				var result = await _resourceLogic.AddResource(resource);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
