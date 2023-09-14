using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Interfaces;
using InvoiceApp.Server.Repositories.EntityFramework;
using InvoiceApp.Server.Repositories.MSSql;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceApp.Server.Extensions
{
    public static class MSSqlExtensions
    {
        public static void AddDependenciesForMSSQL(this IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, MSSQLAddressRepository>();
        }
    }
}
