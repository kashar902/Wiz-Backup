using App.Wiz.Domain.Repositories.AccessRightsRepository;
using App.Wiz.Domain.Repositories.AccountBookCalendarPeriodRepository;
using App.Wiz.Domain.Repositories.AccountSetupRepository;
using App.Wiz.Domain.Repositories.AssignBranchRepository;
using App.Wiz.Domain.Repositories.BranchRepository;
using App.Wiz.Domain.Repositories.BudgetPeriodRepository;
using App.Wiz.Domain.Repositories.BudgetRepository;
using App.Wiz.Domain.Repositories.ChargeFieldRepository;
using App.Wiz.Domain.Repositories.ChargeTypeRepository;
using App.Wiz.Domain.Repositories.CityRepository;
using App.Wiz.Domain.Repositories.CompanyRepository;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.CountryRepository;
using App.Wiz.Domain.Repositories.CreditTermRepository;
using App.Wiz.Domain.Repositories.CurrencyRepository;
using App.Wiz.Domain.Repositories.FieldTypeRepository;
using App.Wiz.Domain.Repositories.FlightClassRepository;
using App.Wiz.Domain.Repositories.FormulaBuilderRepository;
using App.Wiz.Domain.Repositories.FormulaChargeFieldRepository;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Domain.Repositories.GroupRepository;
using App.Wiz.Domain.Repositories.ResourceRepository;
using App.Wiz.Domain.Repositories.RoomRepository;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.Repositories.SuperTypeRepository;
using App.Wiz.Domain.Repositories.TemplatesRepositories;
using App.Wiz.Domain.Repositories.UserRepository;
using App.Wiz.Domain.Repositories.UsersBranchRepository;
using App.Wiz.Domain.Repositories.VehicleRepository;
using Microsoft.Extensions.DependencyInjection;

namespace App.Wiz.Domain;

public static class Startup
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        _ = services.AddServices();
        return services;
    }
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        _ = services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
        _ = services.AddScoped<ICountryRepository, CountryRepository>();
        _ = services.AddScoped<IFormulaBuilderRepository, FormulaBuilderRepository>();
        _ = services.AddScoped<IFieldTypeRepository, FieldTypeRepository>();
        _ = services.AddScoped<IChargeFieldRepository, ChargeFieldRepository>();
        _ = services.AddScoped<IChargeTypeRepository, ChargeTypeRepository>();
        _ = services.AddScoped<IAccountSetupRepository, AccountSetupRepository>();
        _ = services.AddScoped<ISubsidaryAccountRepository, SubsidaryAccountRepository>();
        _ = services.AddScoped<IControlAccountRepository, ControlAccountRepository>();
        _ = services.AddScoped<ITemplateTypeRepository, TemplateTypeRepository>();
        _ = services.AddScoped<ITemplateRepository, TemplateRepository>();
        _ = services.AddScoped<ITemplateFieldsRepository, TemplateFieldsRepository>();
        _ = services.AddScoped<IUsersBranchRepository, UsersBranchRepository>();
        _ = services.AddScoped<IBudgetRepository, BudgetRepository>();
        _ = services.AddScoped<IAssignBranchRepository, AssignBranchRepository>();
        _ = services.AddScoped<IAccessRightsRepository, AccessRightsRepository>();
        _ = services.AddScoped<IAccountBookCalendarPeriodRepository, AccountBookCalendarPeriodRepository>();
        _ = services.AddScoped<IBranchRepository, BranchRepository>();
        _ = services.AddScoped<IBudgetPeriodRepository, BudgetPeriodRepository>();
        _ = services.AddScoped<ICityRepository, CityRepository>();
        _ = services.AddScoped<ICompanyRepository, CompanyRepository>();
        _ = services.AddScoped<ICreditTermRepository, CreditTermRepository>();
        _ = services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        _ = services.AddScoped<IFieldTypeRepository, FieldTypeRepository>();
        _ = services.AddScoped<IFlightClassCategoryRepository, FlightClassCategoryRepository>();
        _ = services.AddScoped<IFlightClassRepository, FlightClassRepository>();
        _ = services.AddScoped<IGroupDetailRepository, GroupDetailRepository>();
        _ = services.AddScoped<IGroupOfCompanyRepository, GroupOfCompanyRepository>();
        _ = services.AddScoped<IGroupRepository, GroupRepository>();
        _ = services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        _ = services.AddScoped<ISuperTypeRepository, SuperTypeRepository>();
        _ = services.AddScoped<IVehicleRepository, VehicleRepository>();
        _ = services.AddScoped<IResourceCategoryRepository, ResourceCategoryRepository>();
        _ = services.AddScoped<IResourcesRepository, ResourcesRepository>();
        _ = services.AddScoped<IUserResourceRepository, UserResourceRepository>();
        _ = services.AddScoped<IUserRepository, UserRepository>();
        _ = services.AddScoped<IRoleRepository, RoleRepository>();
        _ = services.AddScoped<IRoomRepository, RoomRepository>();
        _ = services.AddScoped<IFormulaChargeFieldRepository, FormulaChargeFieldRepository>();

        return services;
    }
}
