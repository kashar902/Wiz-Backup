using App.Wiz.Application.Services.AccountSetupServices;
using App.Wiz.Application.Services.AuthenticationServices;
using App.Wiz.Application.Services.BranchServices;
using App.Wiz.Application.Services.CalendarPeriodServices;
using App.Wiz.Application.Services.ChargeFieldServices;
using App.Wiz.Application.Services.CityServices;
using App.Wiz.Application.Services.CompanyServices;
using App.Wiz.Application.Services.ControlAccountServices;
using App.Wiz.Application.Services.CountryServices;
using App.Wiz.Application.Services.CreditTermServices;
using App.Wiz.Application.Services.CurrencyServices;
using App.Wiz.Application.Services.FlightClassServices;
using App.Wiz.Application.Services.FormulaBuilderServices;
using App.Wiz.Application.Services.GroupServices;
using App.Wiz.Application.Services.ResourceServices;
using App.Wiz.Application.Services.RoomServices;
using App.Wiz.Application.Services.SubsidaryAccountServices;
using App.Wiz.Application.Services.SuperTypeServices;
using App.Wiz.Application.Services.TemplateServices;
using App.Wiz.Application.Services.UserServices;
using App.Wiz.Application.Services.VehicleServices;
using Microsoft.Extensions.DependencyInjection;

namespace App.Wiz.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        _ = services.AddServices();
        return services;
    }
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IFormulaBuilderService, FormulaBuilderService>();
        _ = services.AddScoped<ICountryService, CountryService>();
        _ = services.AddScoped<IAccountSetupService, AccountSetupService>();
        _ = services.AddScoped<IChargeFieldService, ChargeFieldService>();
        _ = services.AddScoped<IUserService, UserService>();
        _ = services.AddScoped<ITemplateService, TemplateService>();
        _ = services.AddScoped<ISubsidaryAccountService, SubsidaryAccountService>();
        _ = services.AddScoped<IControlAccountService, ControlAccountService>();
        _ = services.AddScoped<ICalendarPeriodServices, CalendarPeriodServices>();
        _ = services.AddScoped<ICityService, CityService>();
        _ = services.AddScoped<ICompanyServices, CompanyServices>();
        _ = services.AddScoped<ICreditTermService, CreditTermService>();
        _ = services.AddScoped<ICurrencyServices, CurrencyServices>();
        _ = services.AddScoped<IFlightClassService, FlightClassService>();
        _ = services.AddScoped<IFormulaBuilderService, FormulaBuilderService>();
        _ = services.AddScoped<IGroupService, GroupService>();
        _ = services.AddScoped<ISupertTypeService, SupertTypeService>();
        _ = services.AddScoped<IResourcesService, ResourcesService>();
        _ = services.AddScoped<IVehicleService, VehicleService>();
        _ = services.AddScoped<IAuthenticationService, AuthenticationService>();
        _ = services.AddScoped<IRoomService, RoomService>();
        _ = services.AddScoped<IBranchServices, BranchServices>();
        return services;
    }
}
