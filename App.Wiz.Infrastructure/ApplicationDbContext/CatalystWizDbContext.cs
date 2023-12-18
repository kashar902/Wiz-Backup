using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Infrastructure.ApplicationDbContext;

public class CatalystWizDbContext : DbContext
{
    public CatalystWizDbContext(DbContextOptions<CatalystWizDbContext> options)
            : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Accessright> Accessrights { get; set; }
    public virtual DbSet<AccountSetup> AccountSetup { get; set; }
    public virtual DbSet<ChargeField> ChargeField { get; set; }
    public virtual DbSet<ChargeType> ChargeType { get; set; }
    public virtual DbSet<FieldType> FieldType { get; set; }
    public virtual DbSet<FormulaBuilder> FormulaBuilder { get; set; }
    public virtual DbSet<AccControlAccount> AccControlAccounts { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<UsersBranch> UserBranch { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<GroupOfCompany> GroupOfCompanies { get; set; }
    public virtual DbSet<GroupDetails> GroupDetails { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<UserGroup> UserGroups { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Branch> Branch { get; set; }
    public virtual DbSet<TemplateType> TemplateTypes { get; set; }
    public virtual DbSet<Template> Templates { get; set; }
    public virtual DbSet<CreditTerm> CreditTerms { get; set; }
    public virtual DbSet<TemplateField> TemplateField { get; set; }
    public virtual DbSet<AccSubsidaryAccount> AccSubsidaryAccount { get; set; }
    public virtual DbSet<AccBudgetPeriod> AccBudgetPeriod { get; set; }
    public virtual DbSet<AccAssignBranch> AccAssignBranch { get; set; }
    public virtual DbSet<AccBudget> AccBudget { get; set; }
    public virtual DbSet<FlightClassCategory> FlightClassCategories { get; set; }
    public virtual DbSet<FlightClasses> FlightClass { get; set; }
    public virtual DbSet<AccountBookCalendarPeriod> AccountBookCalenderPeriods { get; set; }
    public virtual DbSet<AccSuperType> AccSuperTypes { get; set; }
    public virtual DbSet<ResourcesCategory> ResourcesCategories { get; set; }
    public virtual DbSet<Resource> Resources { get; set; }
    public virtual DbSet<UsersResource> UsersResources { get; set; }
    public virtual DbSet<UserRole> UserRole { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<License> License { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<FormulaChargeFields> FormulaChargeFields { get; set; }
}
