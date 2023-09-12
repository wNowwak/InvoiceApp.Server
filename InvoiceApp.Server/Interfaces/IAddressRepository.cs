using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IAddressRepository
{
    Task<IList<Address>> GetAddressesAsync();
    Task<Address> GetAddressByIdAsync(int addressId);
    Task<Address> CreateAddress(Address address);
    Task<bool> UpdateAddress(Address address);
    Task<bool> DeleteAddress(int addressId);
}
