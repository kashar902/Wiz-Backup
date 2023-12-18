using App.Wiz.Common.GenericServiceResponse;

namespace App.Wiz.Application.Services.AuthenticationServices;

public interface IAuthenticationService
{
    public Task<ServiceResponse> authentication(string username, string password);
}
