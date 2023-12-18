using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.InvoiceService;

public class InvoiceService : IIService
{
    private readonly UserAndAssociatesdbcontext _dbContext;

    public InvoiceService(UserAndAssociatesdbcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Invoice>> GetAllINvoices()
    {
        var invoice = await _dbContext.Invoices.ToListAsync();
        return invoice;
    }

    public async Task<Invoice> GetByIdINvoice(int id)
    {
        var invoice = await _dbContext.Invoices.FindAsync(id);

        if (invoice == null) throw new ArgumentException($"Invoice with ID {id} does not exist.");

        return invoice;
    }

    public async Task<List<Invoice>> AddInvoices(Invoice invoice)
    {
        var result = _dbContext.Invoices.Add(invoice);
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Invoices.ToListAsync();
    }

    public async Task<List<Invoice>> DeleteInvoice(int id)
    {
        var invoice = await _dbContext.Invoices.FindAsync(id);
        if (invoice == null)
        {
            throw new ArgumentException($"Invoice with ID {id} does not exist.");
        }

        var result = _dbContext.Invoices.Remove(invoice);
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Invoices.ToListAsync();
    }

    public async Task<List<Invoice>> UpdateInvoice(int id, Invoice updatedInvoice)
    {
        var invoice = await _dbContext.Invoices.FindAsync(id);
        if (invoice == null)
        {
            throw new ArgumentException($"Invoice with ID {id} does not exist.");
        }

        invoice.InvoiceCode = updatedInvoice.InvoiceCode;
        invoice.InvoiceDetailId = updatedInvoice.InvoiceDetailId;
        invoice.Date = updatedInvoice.Date;
        invoice.Time = updatedInvoice.Time;
        invoice.CustomerId = updatedInvoice.CustomerId;
        invoice.SupplierId = updatedInvoice.SupplierId;

        await _dbContext.SaveChangesAsync();

        return await _dbContext.Invoices.ToListAsync();
    }

}
