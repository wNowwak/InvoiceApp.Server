using AutoFixture;
using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Repositories.MSSql;

var repo = new MSSQLMeasureUnitRepository();

var address = new MeasureUnit();
var fixture = new Fixture();
//for (int i = 0; i < 100; i++)
//{
    address = fixture.Create<MeasureUnit>();
//    await repo.CreateAddress(address);
//}
address.MeasureUnitId = 1;

//await repo.DeleteAddress(3);
//await repo.GetAddressesAsync();
await repo.DeleteMeasureUnit(1);
//await repo.GetDocumentTypesAsync();