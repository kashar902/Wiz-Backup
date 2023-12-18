using Commons.Messages;
using UserAssociates.Business.Dtos.VisaTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.VisaTypeService;

namespace UserAssociates.Business.Logic.VisaTypeBusinessLogic
{
    public class VisaTypeLogic : IVisaTypeLogic
	{
		private readonly IVisaTypeService _visaTypeService;

		public VisaTypeLogic(IVisaTypeService visaTypeService)
		{
			_visaTypeService = visaTypeService;
		}

		public async Task<string> CreateVisaType(CreateVisaTypeDto createVisaTypeDto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(createVisaTypeDto.Title) ||
					string.IsNullOrWhiteSpace(createVisaTypeDto.Description))
				{
					return Constants.IsNullValue;
				}
				VisaType vt = new()
				{
					Title = createVisaTypeDto.Title,
					Description = createVisaTypeDto.Description
				};
				_ = await _visaTypeService.AddVisaType(vt);
				return Constants.VisaType.CreateSuccessfull;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<string> UpdateVisaType(UpdateVisaTypeDto updateVisaTypeDto)
		{
			try
			{
				VisaType? visaType = await _visaTypeService.GetVisaType(updateVisaTypeDto.ID);
				if (visaType is null)
				{
					return Constants.NotFound;
				}

				if (!string.IsNullOrWhiteSpace(updateVisaTypeDto.Title))
				{
					visaType.Title = updateVisaTypeDto.Title;
				}

				if (!string.IsNullOrWhiteSpace(updateVisaTypeDto.Description))
				{
					visaType.Description = updateVisaTypeDto.Description;
				}

				int successCount = await _visaTypeService.UpdateVisaType(visaType);
				return successCount != 0 ? Constants.VisaType.UpdateSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<VisaTypeViewModel?> GetVisaType(int Id)
		{
			try
			{
				VisaType? visaType = await _visaTypeService.GetVisaType(Id);
				if (visaType is null)
				{
					return null;
				}

				VisaTypeViewModel visaTypeViewModel = new()
				{
					Title = visaType.Title,
					Description = visaType.Description,
					ID = visaType.ID
				};
				return visaTypeViewModel;
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<List<VisaType>> GetAllVisaTypes()
		{
			try
			{
				return await _visaTypeService.GetAllVisaTypes();
			}
			catch (CustomException)
			{
				throw;
			}
		}
		public async Task<string> DeleteVisaType(int id)
		{
			try
			{
				VisaType? visaType = await _visaTypeService.GetVisaType(id);
				if (visaType is null)
				{
					return Constants.NotFound;
				}

				int successCount = await _visaTypeService.DeleteVisaType(visaType);
				return successCount != 0 ? Constants.VisaType.DeleteSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}
	}
}
