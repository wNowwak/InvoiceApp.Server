using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IContractorRepository
{
    Task<IList<Contractor>> GetContractorsAsync();
    Task<Contractor> GetContractorByIdAsync(int contractorId);
    Task<Contractor> CreateContractor(Contractor contractor);
    Task<bool> UpdateContractor(Contractor contractor);
    Task<bool> DeleteContractor(int contractorId);
}
