using Commons.Messages;
using UserAssociates.Business.Dtos.VisitTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.VisitTypeService;

namespace UserAssociates.Business.Logic.VisitTypeBusinessLogic
{
    public class VisitTypeLogic : IVisitTypeLogic
	{
		private readonly IVisitTypeService _visitTypeService;

		public VisitTypeLogic(IVisitTypeService visitTypeService)
		{
			_visitTypeService = visitTypeService;
		}

		public async Task<string> CreateVisitType(CreateVisitTypeDto createVisitTypeDto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(createVisitTypeDto.Title) ||
					string.IsNullOrWhiteSpace(createVisitTypeDto.Description) ||
					string.IsNullOrWhiteSpace(createVisitTypeDto.SaleInvoicePrefix) ||
					string.IsNullOrWhiteSpace(createVisitTypeDto.RefundInvoicePrefix))
				{
					return Constants.IsNullValue;
				}
				VisitType vt = new()
				{
					Title = createVisitTypeDto.Title,
					Description = createVisitTypeDto.Description,
					SaleInvoicePrefix = createVisitTypeDto.SaleInvoicePrefix,
					RefundInvoicePrefix = createVisitTypeDto.RefundInvoicePrefix
				};
				_ = await _visitTypeService.AddVisitType(vt);
				return Constants.VisitType.CreateSuccessfull;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<string> UpdateVisitType(UpdateVisitTypeDto updateVisitTypeDto)
		{
			try
			{
				VisitType? visitType = await _visitTypeService.GetVisitType(updateVisitTypeDto.ID);
				if (visitType is null)
				{
					return Constants.NotFound;
				}

				if (!string.IsNullOrWhiteSpace(updateVisitTypeDto.Title))
				{
					visitType.Title = updateVisitTypeDto.Title;
				}

				if (!string.IsNullOrWhiteSpace(updateVisitTypeDto.Description))
				{
					visitType.Description = updateVisitTypeDto.Description;
				}

				if (!string.IsNullOrWhiteSpace(updateVisitTypeDto.SaleInvoicePrefix))
				{
					visitType.SaleInvoicePrefix = updateVisitTypeDto.SaleInvoicePrefix;
				}

				if (!string.IsNullOrWhiteSpace(updateVisitTypeDto.RefundInvoicePrefix))
				{
					visitType.RefundInvoicePrefix = updateVisitTypeDto.RefundInvoicePrefix;
				}

				int successCount = await _visitTypeService.UpdateVisitType(visitType);
				return successCount != 0 ? Constants.VisitType.UpdateSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<VisitTypeViewModel?> GetVisitType(int Id)
		{
			try
			{
				VisitType? visitType = await _visitTypeService.GetVisitType(Id);
				if (visitType is null)
				{
					return null;
				}

				VisitTypeViewModel visitTypeViewModel = new()
				{
					Title = visitType.Title,
					Description = visitType.Description,
					SaleInvoicePrefix = visitType.SaleInvoicePrefix,
					RefundInvoicePrefix = visitType.RefundInvoicePrefix,
					ID = visitType.ID
				};
				return visitTypeViewModel;
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<List<VisitType>> GetAllVisitTypes()
		{
			try
			{
				return await _visitTypeService.GetAllVisitTypes();
			}
			catch (CustomException)
			{
				throw;
			}
		}

		public async Task<string> DeleteVisitType(int id)
		{
			try
			{
				VisitType? visitType = await _visitTypeService.GetVisitType(id);
				if (visitType is null)
				{
					return Constants.NotFound;
				}

				int successCount = await _visitTypeService.DeleteVisitType(visitType);
				return successCount != 0 ? Constants.VisitType.DeleteSuccessfull : Constants.Error;
			}
			catch (CustomException)
			{
				throw;
			}
		}

	}
}
