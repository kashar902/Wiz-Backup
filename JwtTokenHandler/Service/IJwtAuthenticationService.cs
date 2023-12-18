namespace App.Wiz.Token.Service;

public interface IJwtAuthenticationService
{
    string GenerateToken(string username, string userType, string agencyCode);
}
