using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IList<Warehouse>> GetWarehousesAsync();
        Task<Warehouse> GetWarehouseByIdAsync(int warehouseId);
        Task<Warehouse> CreateWarehouse(Warehouse warehouse);
        Task<bool> UpdateWarehouse(Warehouse warehouse);
        Task<bool> DeleteWarehouse(int warehouseId);
    }
}
