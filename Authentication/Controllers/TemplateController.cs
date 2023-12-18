using App.Wiz.Application.Services.SubsidaryAccountServices;
using App.Wiz.Application.Services.TemplateServices;
using App.Wiz.Domain.ServiceDtos.TemplateDtos;
using Microsoft.AspNetCore.Mvc;

namespace App.Wiz.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TemplateController : ControllerBase
{
    private readonly ITemplateService _service;
    private readonly ISubsidaryAccountService _subsidaryAccountService;

    public TemplateController(ITemplateService service,
        ISubsidaryAccountService subsidaryAccountService)
    {
        _service = service;
        _subsidaryAccountService = subsidaryAccountService;
    }



    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateTemplateDto dto)
    {
        return Ok(await _service.Create(dto));
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int templateTypeId)
    {
        return Ok(await _service.GetAll(templateTypeId));
    }



    [HttpGet("Get/{templateId:int}/{templateTypeId:int}")]
    public async Task<IActionResult> GetHotel(int templateTypeId, int templateId)
    {
        return Ok(await _service.GetById(templateId, templateTypeId));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateTemplate(UpdateTemplateDto updateTemplate)
    {
        return Ok(await _service.UpdateTemplate(updateTemplate));
    }


    [HttpDelete("Delete/{templateId}")]
    public async Task<IActionResult> DeleteTemplate(int templateId)
    {
        return Ok(await _service.DeleteTemplate(templateId));
    }

    [HttpGet("GetCustomerSupplierDropDown")]
    public async Task<IActionResult> GetCustomerSupplierDropDown()
    {
        return Ok(await _subsidaryAccountService.GetCustomerSupplierDropDown());
    }
    [HttpGet("GetFlightClass")]
    public async Task<IActionResult> GetFlightClass()
    {
        return Ok(await _subsidaryAccountService.GetCustomerSupplierDropDown());
    }
}