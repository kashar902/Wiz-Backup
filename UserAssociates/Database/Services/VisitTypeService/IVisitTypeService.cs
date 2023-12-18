using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisitTypeService
{
    public interface IVisitTypeService
    {
        Task<VisitType> AddVisitType(VisitType visitType);
        Task<int> DeleteVisitType(VisitType visitType);
        Task<List<VisitType>> GetAllVisitTypes();
        Task<VisitType?> GetVisitType(int Id);
        Task<int> UpdateVisitType(VisitType visitType);
    }
}
