using UserAssociates.Business.Dtos.VisaTypeDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.VisaTypeBusinessLogic
{
    public interface IVisaTypeLogic
    {
        Task<string> CreateVisaType(CreateVisaTypeDto createVisaTypeDto);
        Task<string> UpdateVisaType(UpdateVisaTypeDto updateVisaTypeDto);
        Task<VisaTypeViewModel?> GetVisaType(int Id);
        Task<List<VisaType>> GetAllVisaTypes();
        Task<string> DeleteVisaType(int id);
    }
}
