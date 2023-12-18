using JwtTokenHandler.Service;
using Microsoft.EntityFrameworkCore;
using SharedService.Business.Logic.CityBusinessLogic;
using SharedService.Business.Logic.CountryBusinessLogic;
using SharedService.Business.Logic.CreditTermBusinessLogic;
using SharedService.Business.Logic.CurrencyBusinessLogic;
using SharedService.Business.Logic.FlightClassBusinessLogic;
using SharedService.Business.Logic.FlightClassCategoryLogic;
using SharedService.Business.Logic.RoomBusinessLogic;
using SharedService.Business.Logic.VehicleBusinessLogic;
using SharedService.Database.DBContext;
using SharedService.Database.Services.CityService;
using SharedService.Database.Services.CountryService;
using SharedService.Database.Services.CreditTermService;
using SharedService.Database.Services.CurrencyService;
using SharedService.Database.Services.FlightClassCategoryService;
using SharedService.Database.Services.FlightClassService;
using SharedService.Database.Services.RoomService;
using SharedService.Database.Services.VehicleService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

JwtAuthenticationConfig.Configure(
	builder.Services
	, builder.Configuration["Jwt:Key"]
	);

builder.Services.AddDbContext<SharedServicedbcontext>(
	options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryLogic, CountryLogic>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityLogic, CityLogic>();
builder.Services.AddScoped<IFlightClassCategoryService, FlightClassCategoryService>();
builder.Services.AddScoped<IFlightClassCategoryLogic, FlightClassCategoryLogic>();
builder.Services.AddScoped<ICreditTermService, CreditTermService>();
builder.Services.AddScoped<ICreditTermLogic, CreditTermLogic>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyLogic, CurrencyLogic>();
builder.Services.AddScoped<IFlightClassService, FlightClassesService>();
builder.Services.AddScoped<IFlightClassBusinessLogic, FlightClassBusinessLogic>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomBusinessLogic, RoomBusinessLogic>();
builder.Services.AddScoped<IVehicleBusinessLogic, VehicleBusinessLogic>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.RoutePrefix = "";
	c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
}
);

app.Run();
