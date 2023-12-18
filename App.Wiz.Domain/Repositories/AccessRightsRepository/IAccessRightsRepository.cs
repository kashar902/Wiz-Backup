using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.AccessRightsRepository;

public interface IAccessRightsRepository : IRepository<Accessright>
{
    Task<Accessright?> GetAccessright(bool isRead, bool isCreate, bool isUpdate, bool isDelete);
}