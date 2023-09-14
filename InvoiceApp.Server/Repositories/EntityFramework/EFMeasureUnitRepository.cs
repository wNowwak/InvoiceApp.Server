using InvoiceApp.Commons.Models;
using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Server.Repositories.EntityFramework
{
    internal class EFMeasureUnitRepository : EFBaseRepository, IMeasureUnitRepository
    {
        public EFMeasureUnitRepository(InvoiceContext context) : base(context)
        {
        }

        public async Task<MeasureUnit> CreateMeasureUnit(MeasureUnit measureUnit)
        {
            await _context.MeasureUnits.AddAsync(measureUnit);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return measureUnit;
            return null;
        }

        public async Task<bool> DeleteMeasureUnit(int measureUnitId)
        {
            var addressToDelete = _context.MeasureUnits.First(_ => _.MeasureUnitId.Equals(measureUnitId));
            _context.MeasureUnits.Remove(addressToDelete);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<MeasureUnit> GetMeasureUnitByIdAsync(int measureUnitId)
        {
            var result = await _context.MeasureUnits.FirstAsync(_ => _.MeasureUnitId.Equals(measureUnitId));

            return result;
        }

        public async Task<IList<MeasureUnit>> GetMeasureUnitsAsync()
        {
            return await _context.MeasureUnits.ToListAsync();
        }

        public async Task<bool> UpdateMeasureUnit(MeasureUnit measureUnit)
        {
            _context.MeasureUnits.Update(measureUnit);
            var result = await _context.SaveChangesAsync();
            
            return result > 0;
        }
    }
}
