using UserAssociates.Database.Models;
using UserAssociates.Database.Services.InvoiceService;

namespace UserAssociates.Business.Logic.InvoiceBusiness;

public class InvoiceLogic : IInvoiceLogic
{
	private readonly IIService _invoiceService;

	public InvoiceLogic(IIService invoiceService)
	{
		_invoiceService = invoiceService;
	}

	public async Task<List<Invoice>> GetAllInvoices()
	{
		try
		{
			var result = await _invoiceService.GetAllINvoices();
			return result;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<Invoice> GetByIdInvoice(int id)
	{
		try
		{
			var result = await _invoiceService.GetByIdINvoice(id);
			return result;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<List<Invoice>> AddInvoices(Invoice invoice)
	{
		try
		{
			var result = await _invoiceService.AddInvoices(invoice);
			return result;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<List<Invoice>> DeleteInvoices(int id)
	{
		try
		{
			var result = await _invoiceService.DeleteInvoice(id);
			return result;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<List<Invoice>> UpdateInvoice(int id, Invoice invoice)
	{
		try
		{
			var result = await _invoiceService.UpdateInvoice(id, invoice);
			return result;

		}
		catch (Exception)
		{
			throw;
		}
	}
}
