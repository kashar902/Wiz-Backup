using JwtTokenHandler.Service;
using Microsoft.EntityFrameworkCore;
using UserAssociates.Business.Logic.AssignMemberGroupBusiness;
using UserAssociates.Business.Logic.AssignResourceGroupBusiness;
using UserAssociates.Business.Logic.BookingCategoryBusinessLogic;
using UserAssociates.Business.Logic.CatalystBranchPreferenceBusiness;
using UserAssociates.Business.Logic.CatalystCheckboxBusiness;
using UserAssociates.Business.Logic.CatalystDateLockBusiness;
using UserAssociates.Business.Logic.CatalystDefaultBusiness;
using UserAssociates.Business.Logic.CatalystFixedChargeFieldsBusiness;
using UserAssociates.Business.Logic.CatalystGeneralBusiness;
using UserAssociates.Business.Logic.CatalystNumberSchemeBusiness;
using UserAssociates.Business.Logic.ChargeFieldBusinessLogic;
using UserAssociates.Business.Logic.CityBusinessLogic;
using UserAssociates.Business.Logic.CutomerTypeBusinessLogic;
using UserAssociates.Business.Logic.FormulaBuilderBusinessLogic;
using UserAssociates.Business.Logic.GeneralBusiness;
using UserAssociates.Business.Logic.GroupBusiness;
using UserAssociates.Business.Logic.HotelInventoryBusiness;
using UserAssociates.Business.Logic.InvoiceBusiness;
using UserAssociates.Business.Logic.ResourceBusiness;
using UserAssociates.Business.Logic.UserBusiness;
using UserAssociates.Business.Logic.VisaSMSBusiness;
using UserAssociates.Business.Logic.VisaTypeBusinessLogic;
using UserAssociates.Business.Logic.VisitTypeBusinessLogic;
using UserAssociates.Business.Logic.VoucherBusiness;
using UserAssociates.Business.Logic.VoucherTypeBusinessLogic;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Services.BookingCategoryService;
using UserAssociates.Database.Services.CatalystBranchPrefService;
using UserAssociates.Database.Services.CatalystCheckboxService;
using UserAssociates.Database.Services.CatalystDateLockService;
using UserAssociates.Database.Services.CatalystDefaultService;
using UserAssociates.Database.Services.CatalystFixedChargeFieldsService;
using UserAssociates.Database.Services.CatalystGeneralService;
using UserAssociates.Database.Services.CatalystNumberSchemeService;
using UserAssociates.Database.Services.ChargeFieldService;
using UserAssociates.Database.Services.CityTaxService;
using UserAssociates.Database.Services.CustomerTypeService;
using UserAssociates.Database.Services.FormulaBuilderService;
using UserAssociates.Database.Services.GeneralService;
using UserAssociates.Database.Services.GroupService;
using UserAssociates.Database.Services.HotelInventoryService;
using UserAssociates.Database.Services.InvoiceService;
using UserAssociates.Database.Services.MemberGroupService;
using UserAssociates.Database.Services.ResourceGroupService;
using UserAssociates.Database.Services.ResourceService;
using UserAssociates.Database.Services.UserService;
using UserAssociates.Database.Services.VisaSMSService;
using UserAssociates.Database.Services.VisaTypeService;
using UserAssociates.Database.Services.VisitTypeService;
using UserAssociates.Database.Services.VoucherService;
using UserAssociates.Database.Services.VoucherTypeService;


var builder = WebApplication.CreateBuilder(args);

#region ASH

#endregion

// Add services to the container.

JwtAuthenticationConfig.Configure(
    builder.Services
    , builder.Configuration["Jwt:Key"]
    );

builder.Services.AddDbContext<UserAndAssociatesdbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICGLogic, CGLogic>();
builder.Services.AddScoped<ICGService, CGService>();
builder.Services.AddScoped<ICDLogic, CDLogic>();
builder.Services.AddScoped<ICDService, CDService>();
builder.Services.AddScoped<ICCLogic, CCLogic>();
builder.Services.AddScoped<ICCService, CCService>();
builder.Services.AddScoped<ICDLLogic, CDLLogic>();
builder.Services.AddScoped<ICDLService, CDLService>();
builder.Services.AddScoped<ICNSLogic, CNSLogic>();
builder.Services.AddScoped<ICNSService, CNSService>();
builder.Services.AddScoped<ICFCFLogic, CFCFLogic>();
builder.Services.AddScoped<ICFCFService, CFCFService>();
builder.Services.AddScoped<ICBPLogic, CBPLogic>();
builder.Services.AddScoped<ICBPService, CBPService>();
builder.Services.AddScoped<IGLogic, GLogic>();
builder.Services.AddScoped<IGService, GService>();
builder.Services.AddScoped<IHILogic, HILogic>();
builder.Services.AddScoped<IHIService, HIService>();
builder.Services.AddScoped<IVSLogic, VSLogic>();
builder.Services.AddScoped<IVSService, VSService>();
builder.Services.AddScoped<IVoucherSLogic, VoucherSLogic>();
builder.Services.AddScoped<IVoucherSService, VoucherSService>();
builder.Services.AddScoped<IGroupLogic, GroupLogic>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IResLogic, ResLogic>();
builder.Services.AddScoped<IResService, ResService>();
builder.Services.AddScoped<IARGLogic, ARGLogic>();
builder.Services.AddScoped<IARGService, ARGService>();
builder.Services.AddScoped<IAMGLogic, AMGLogic>();
builder.Services.AddScoped<IAMGService, AMGService>();
builder.Services.AddScoped<IInvoiceLogic, InvoiceLogic>();
builder.Services.AddScoped<IIService, InvoiceService>();
builder.Services.AddScoped<ICityTaxBusinessLogic, CityTaxBusinessLogic>();
builder.Services.AddScoped<ICityTaxService, CityTaxService>();
builder.Services.AddScoped<IBookingCategoryService, BookingCategoryService>();
builder.Services.AddScoped<IBookingCategoryLogic, BookingCategoryLogic>();
builder.Services.AddScoped<IChargeFieldBusinessLogic, ChargeFieldBusinessLogic>();
builder.Services.AddScoped<IChargeFieldService, ChargeFieldService>();
builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();
builder.Services.AddScoped<ICustomerTypeLogic, CustomerTypeLogic>();
builder.Services.AddScoped<IFormulaBuilderBusinessLogic, FormulaBuilderBusinessLogic>();
builder.Services.AddScoped<IFormulaBuilderService, FormulaBuilderService>();
builder.Services.AddScoped<IVoucherTypeService, VoucherTypeService>();
builder.Services.AddScoped<IVoucherTypeBusinessLogic, VoucherTypeBusinessLogic>();
builder.Services.AddScoped<IVisaTypeLogic, VisaTypeLogic>();
builder.Services.AddScoped<IVisaTypeService, VisaTypeService>();
builder.Services.AddScoped<IVisitTypeService, VisitTypeService>();
builder.Services.AddScoped<IVisitTypeLogic, VisitTypeLogic>();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
