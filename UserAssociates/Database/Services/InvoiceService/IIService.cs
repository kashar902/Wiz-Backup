using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.InvoiceService;

public interface IIService
{
    Task<List<Invoice>> GetAllINvoices();

    Task<Invoice> GetByIdINvoice(int id);

    Task<List<Invoice>> AddInvoices(Invoice invoice);

    Task<List<Invoice>> UpdateInvoice(int id, Invoice updatedInvoice);

    Task<List<Invoice>> DeleteInvoice(int id);

}
