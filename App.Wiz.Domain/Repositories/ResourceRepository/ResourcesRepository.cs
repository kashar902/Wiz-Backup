using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ResourceRepository
{
    public class ResourcesRepository : Repository<Resource>, IResourcesRepository
    {
        public ResourcesRepository(CatalystWizDbContext context)
         : base (context)
        {
                
        }
    }
}
