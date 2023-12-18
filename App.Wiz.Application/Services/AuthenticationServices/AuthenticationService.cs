using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Domain.Repositories.UserRepository;
using App.Wiz.Infrastructure.Entities;
using App.Wiz.Token.Service;

namespace App.Wiz.Application.Services.AuthenticationServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _repository;
    private readonly IJwtAuthenticationService _jwtAuthenticationService;

    public AuthenticationService(IUserRepository repository, IJwtAuthenticationService jwtAuthenticationService)
    {
        _repository = repository;
        _jwtAuthenticationService = jwtAuthenticationService;
    }

    public async Task<ServiceResponse> authentication(string username, string password)
    {
        Users? value = await _repository.checkuser(username, password);
        if (value is not null)
        {
            string token = "";
            if ((value.Username == username || value.EmailAddress == username) && password == value.Password)
            {
                UsersBranch? usersBranch = await _repository.GetDefaultUserAgency(value.ID);
                if (usersBranch is null)
                {
                    return ServiceResponse.Failure(Constants.NotFound);
                }
                Global.Username = value.Username!;
                Global.CompanyId = usersBranch != null ? usersBranch.CompanyId : 1;
                Global.BranchId = usersBranch != null ? usersBranch.BranchId : 1;
                Global.UserId = value.ID;
                //Global.CurrencyId = company?.CurrencyId ?? 2;
                //Global.AgencyCode = value.AgencyCode;
                string licenseStatus = await verifylicense(usersBranch != null ? usersBranch.Branch!.ID : 0);
                if (licenseStatus == Constants.License.LicenseVerified)
                {
                    UserRole? userRole = await _repository.GetUserRole(value.ID);
                    token = _jwtAuthenticationService.GenerateToken(
                        username,
                        userRole!.RoleId.ToString(),
                        usersBranch != null ? usersBranch.Branch!.ID.ToString() : "0"
                        );
                    return ServiceResponse.Success("Token", token);
                } else
                {
                    return ServiceResponse.Failure(Constants.NotFound);
                }
            }
            return ServiceResponse.Success("Token", token);
        } else
        {
            return ServiceResponse.Failure(Constants.LoginMessage.InvalidCredentials);
        }
    }
    public async Task<string> verifylicense(int agencyid)
    {
        string result = await _repository.VerifyLicense(agencyid);
        return result;
    }

}
