using App.Wiz.Application;
using App.Wiz.Common;
using App.Wiz.Common.Middleware;
using App.Wiz.Domain;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Token.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Register Controllers with Validation Filter
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Keys
            .SelectMany(key => context.ModelState[key]!.Errors.Select(x => new { Field = key, Error = x.ErrorMessage }))
            .ToList();

        var result = new
        {
            IsSuccess = false,
            Message = "One or more validation errors occurred.",
            Data = errors
        };

        return new JsonResult(result)
        {
            StatusCode = StatusCodes.Status400BadRequest,
            ContentType = "application/json"
        };
    };
});

builder.Services
        .AddApplication()
        .AddDomain()
        .AddCommon();

// Add Database Context
builder.Services
    .AddDbContext<CatalystWizDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register HttpClient
builder.Services.AddScoped<HttpClient>();


// JWT Services
builder.Services.AddScoped<IJwtParams, JwtParams>();
builder.Services.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>();

builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

WebApplication app = builder.Build();

// Configure the HTTP request pipeline

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
