using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface ITaxRepository
{
    Task<IList<Tax>> GetTaxsAsync();
    Task<Tax> GetTaxByIdAsync(int taxId);
    Task<Tax> CreateTax(Tax tax);
    Task<bool> UpdateTax(Tax tax);
    Task<bool> DeleteTax(int taxId);
}
