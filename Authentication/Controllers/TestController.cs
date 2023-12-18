using App.Wiz.Application.Services.CountryServices;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ICountryService _countryService;
    public TestController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("GetAllCountry")]
    public async Task<IActionResult> GetAllCountry()
    {
        ServiceResponse result = await _countryService.GetAllCountries();
        return Ok(result);
    }
}
