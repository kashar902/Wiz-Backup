using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.MemberGroupService
{
	public class AMGService : IAMGService
	{
		private readonly UserAndAssociatesdbcontext _dbContext;
		public AMGService(UserAndAssociatesdbcontext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<string> AddMemberGroup(List<AssignMemberGroup> amg)
		{
			_dbContext.AssignMemberGroup.AddRange(amg);
			await _dbContext.SaveChangesAsync();
			return "Member assigned successfully";
		}

		public async Task<List<AssignMemberGroup>> GetAllMemberGroup()
		{

			var amg = await _dbContext.AssignMemberGroup.ToListAsync();
			return amg;
		}
	}
}
