using App.Wiz.Common.Messages;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.UserRepository;
public class UserRepository : Repository<Users>, IUserRepository
{
    public UserRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
    public async Task<Users?> checkuser(string username, string password)
    {
        return await _dbContext
            .Users.Where(x => (x.Username == username || x.EmailAddress == username) && x.Password == password && x.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<string> updatepassword(UpdatePassword model)
    {
        Users? val = await _dbContext.Users.Where(u => u.ID == model.UserId && string.Equals(u.Password, model.OldPassword, StringComparison.Ordinal)).FirstOrDefaultAsync();
        if (val != null)
        {
            val.Password = model.NewPassword;
            _dbContext.Entry(val).State = EntityState.Modified;
            _ = await _dbContext.SaveChangesAsync();
            return Constants.UpdateSuccessful;
        } else
        {
            return Constants.LoginMessage.NoUserFound;
        }
    }

    public async Task<UsersBranch?> GetDefaultUserAgency(int userId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.Branch)
            .Where(a => a.UserId == userId && a.DefaultBranch)
            .FirstOrDefaultAsync();
    }

    public async Task<UserRole?> GetUserRole(int userId)
    {
        return await _dbContext.UserRole
            .Include(x => x.User)
            .Include(x => x.Role)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();
    }
    public async Task<string> VerifyLicense(int id)
    {

        License? license = await _dbContext.License.Where(x => x.enddate > DateTime.Today).FirstOrDefaultAsync();
        return license != null ? Constants.License.LicenseVerified : Constants.License.LicenseExpired;
    }

}
