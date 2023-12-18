using App.Wiz.Common.GenericServiceResponse;

namespace App.Wiz.Application.Services.SuperTypeServices;

public interface ISupertTypeService
{
    Task<ServiceResponse> GetAllAsync();
}
