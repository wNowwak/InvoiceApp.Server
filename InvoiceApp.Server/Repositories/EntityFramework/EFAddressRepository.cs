using InvoiceApp.Commons.Models;
using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Extensions;
using InvoiceApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Server.Repositories.EntityFramework
{
    internal class EFAddressRepository : EFBaseRepository, IAddressRepository
    {
        public EFAddressRepository(InvoiceContext context) : base(context)
        {
        }

        public async Task<Address> CreateAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
                return address;
            return null;
        }

        public async Task<bool> DeleteAddress(int addressId)
        {
            var addressToDelete = _context.Addresses.First(_ => _.AddressId == addressId);
            _context.Addresses.Remove(addressToDelete);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            var result = await _context.Addresses.FirstAsync(_ => _.AddressId.Equals(addressId));

            return result;
        }

        public async Task<IList<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
