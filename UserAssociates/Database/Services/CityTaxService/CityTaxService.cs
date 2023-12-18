using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CityTaxService
{
	public class CityTaxService : ICityTaxService
	{
		private readonly UserAndAssociatesdbcontext _dbContext;
		public CityTaxService(UserAndAssociatesdbcontext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<CityTax> AddCityTax(CityTax cityTax)
		{
			EntityEntry<CityTax> entityEntry = await _dbContext.AddAsync(cityTax);
			_ = await _dbContext.SaveChangesAsync();
			return entityEntry.Entity;
		}

		public async Task<int> DeleteCityTax(CityTax cityTax)
		{
			_ = _dbContext.CityTaxes.Remove(cityTax);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<List<CityTax>> GetAllCityTaxes()
		{
			return await _dbContext.CityTaxes.ToListAsync();
		}

		public async Task<CityTax?> GetCityTax(int Id)
		{
			return await _dbContext.CityTaxes.FirstOrDefaultAsync(x => x.ID == Id);
		}

		public async Task<int> UpdateCityTax(CityTax cityTax)
		{
			_dbContext.Entry(cityTax).State = EntityState.Modified;
			return await _dbContext.SaveChangesAsync();
		}
	}
}
