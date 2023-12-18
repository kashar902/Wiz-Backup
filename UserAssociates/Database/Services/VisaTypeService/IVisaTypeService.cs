using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisaTypeService
{
    public interface IVisaTypeService
    {
        Task<VisaType> AddVisaType(VisaType visaType);
        Task<int> DeleteVisaType(VisaType visaType);
        Task<List<VisaType>> GetAllVisaTypes();
        Task<VisaType?> GetVisaType(int Id);
        Task<int> UpdateVisaType(VisaType visaType);
    }
}
