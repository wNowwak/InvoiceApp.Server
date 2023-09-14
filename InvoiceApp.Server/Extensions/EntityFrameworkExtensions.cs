using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Interfaces;
using InvoiceApp.Server.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceApp.Server.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static void AddDependenciesForEF(this IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, EFAddressRepository>();
            services.AddTransient<IDocumentTypeRepository, EFDocumentTypeRepository>();
            services.AddTransient<IMeasureUnitRepository, EFMeasureUnitRepository>();
            services.AddDbContext<InvoiceContext>(option =>
            {
                option.UseSqlServer(@"Data Source=PIEC\DEVSERVER;Initial Catalog=masterThesisEF;Integrated Security=True;TrustServerCertificate=True");
            });
        }

        public static void CheckMigrations(this DbContext dbContext)
        {
            if(dbContext.Database.GetPendingMigrations().Any())
                dbContext.Database.Migrate();
        }
    }
}
