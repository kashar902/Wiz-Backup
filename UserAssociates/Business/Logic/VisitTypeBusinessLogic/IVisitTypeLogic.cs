using UserAssociates.Business.Dtos.VisitTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.VisitTypeBusinessLogic
{
    public interface IVisitTypeLogic
    {
        Task<string> CreateVisitType(CreateVisitTypeDto createVisitTypeDto);
        Task<string> UpdateVisitType(UpdateVisitTypeDto updateVisitTypeDto);
        Task<VisitTypeViewModel?> GetVisitType(int Id);
        Task<List<VisitType>> GetAllVisitTypes();
        Task<string> DeleteVisitType(int id);
    }
}
