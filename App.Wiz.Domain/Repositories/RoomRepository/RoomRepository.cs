using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.RoomRepository;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(CatalystWizDbContext context)
        : base(context)
    {


    }
}
