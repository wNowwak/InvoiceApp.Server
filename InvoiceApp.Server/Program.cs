using AutoFixture;
using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Repositories.MSSql;
using Microsoft.Extensions.Hosting;
using InvoiceApp.Server.Extensions;
using InvoiceApp.Server.Interfaces;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        //builder.Services.AddDependenciesForMSSQL();
        builder.Services.AddDependenciesForEF();
        var app = builder.Build();

        var repo = app.Services.GetService<IAddressRepository>();

        var address = new Address();
        var fixture = new Fixture();
        //for (int i = 0; i < 100; i++)
        //{
        address = fixture.Build<Address>().Without(_ => _.AddressId).Create<Address>();
        //    await repo.CreateAddress(address);
        //}
        address.AddressId = 2;
        //var result = await repo.UpdateAddress(address);
        //app.Run();
    }
}
//await repo.GetDocumentTypesAsync();