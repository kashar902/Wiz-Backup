using Microsoft.EntityFrameworkCore;
using SharedService.Database.Models;

namespace SharedService.Database.DBContext
{
    public class SharedServicedbcontext : DbContext
    {
        public SharedServicedbcontext(DbContextOptions<SharedServicedbcontext> options)
            : base(options)
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<FlightClassCategory> FlightClassCategories { get; set; }
        public virtual DbSet<CreditTerm> CreditTerms { get; set; }
        public virtual DbSet<FlightClasses> FlightClass { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
    }
}
