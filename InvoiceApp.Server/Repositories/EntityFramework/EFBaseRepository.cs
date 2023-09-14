using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Extensions;

namespace InvoiceApp.Server.Repositories.EntityFramework
{
    internal abstract class EFBaseRepository
    {
        protected readonly InvoiceContext _context;
        public EFBaseRepository(InvoiceContext context)
        {
            _context = context;
            _context.CheckMigrations();
        }
    }
}
