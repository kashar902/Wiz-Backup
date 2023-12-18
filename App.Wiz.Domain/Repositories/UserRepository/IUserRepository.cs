using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.UserRepository;

public interface IUserRepository : IRepository<Users>
{
    Task<Users?> checkuser(string username, string password);
    Task<UsersBranch?> GetDefaultUserAgency(int userId);
    Task<UserRole?> GetUserRole(int userId);
    Task<string> updatepassword(UpdatePassword model);
    Task<string> VerifyLicense(int id);
}