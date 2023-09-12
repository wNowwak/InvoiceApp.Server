using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IMeasureUnitRepository
{
    Task<IList<MeasureUnit>> GetMeasureUnitsAsync();
    Task<MeasureUnit> GetMeasureUnitByIdAsync(int measureUnitId);
    Task<MeasureUnit> CreateMeasureUnit(MeasureUnit measureUnit);
    Task<bool> UpdateMeasureUnit(MeasureUnit measureUnit);
    Task<bool> DeleteMeasureUnit(int measureUnitId);
}
