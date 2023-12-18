using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.InvoiceBusiness;

public interface IInvoiceLogic
{
    Task<List<Invoice>> GetAllInvoices();
    Task<Invoice> GetByIdInvoice(int id);
    Task<List<Invoice>> AddInvoices(Invoice invoice);
    Task<List<Invoice>> DeleteInvoices(int id);
    Task<List<Invoice>> UpdateInvoice(int id, Invoice invoice);
}
