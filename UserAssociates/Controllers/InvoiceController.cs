using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAssociates.Business.Logic.InvoiceBusiness;
using UserAssociates.Database.Models;

namespace UserAssociates.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceLogic _invoiceLogic;
    public InvoiceController(IInvoiceLogic invoiceLogic)
    {
        _invoiceLogic = invoiceLogic;

    }

    [HttpGet("Get")]

    [Authorize]
    public async Task<ActionResult<List<Invoice>>> Get()
    {
        try
        {
            string token = HttpContext.Request.Headers["Authorization"].ToString();
            return await _invoiceLogic.GetAllInvoices();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<Invoice>> Get(int id)
    {
        try
        {
            return await _invoiceLogic.GetByIdInvoice(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<List<Invoice>>> Delete(int id)
    {
        try
        {
            return await _invoiceLogic.DeleteInvoices(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost("Add")]
    public async Task<ActionResult<List<Invoice>>> Add(Invoice invoice)
    {
        try
        {
            return await _invoiceLogic.AddInvoices(invoice);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<List<Invoice>>> Update(int id, Invoice invoice)
    {
        try
        {
            return await _invoiceLogic.UpdateInvoice(id, invoice);
        }
        catch (Exception)
        {
            throw;
        }
    }

    //For testing purpose
    [HttpGet("Developer")]
    [Authorize]
    public IActionResult GetResult()
    {
        return Ok(new
        {
            Developer = "ASHAR ULLAH KHAN!"
        });
    }
}
