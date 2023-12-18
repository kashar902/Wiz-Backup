using UserAssociates.Database.Models;
using UserAssociates.Database.Services.ResourceService;

namespace UserAssociates.Business.Logic.ResourceBusiness
{
	public class ResLogic : IResLogic
	{
		private readonly IResService _resourceService;
		public ResLogic(IResService resourceService)
		{
			_resourceService = resourceService;
		}
		public async Task<List<Resources>> GetAllResources()
		{
			try
			{
				var value = await _resourceService.GetAllResources();
				return value;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<List<Resources>> AddResource(Resources resources)
		{

			try
			{
				var value = await _resourceService.AddResource(resources);
				return value;

			}
			catch (CustomException)
			{
				throw;
			}
		}
	}
}
