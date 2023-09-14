using InvoiceApp.Commons.Models;
using InvoiceApp.Server.DbContexts;
using InvoiceApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Server.Repositories.EntityFramework
{
    internal class EFDocumentTypeRepository : EFBaseRepository, IDocumentTypeRepository
    {

        public EFDocumentTypeRepository(InvoiceContext context) : base(context)
        {
        }

        public async Task<DocumentType> CreateDocumentType(DocumentType documentType)
        {
            await _context.DocumentTypes.AddAsync(documentType);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return documentType;
            return null;
        }

        public async Task<bool> DeleteDocumentType(int documentTypeId)
        {
            var documentTypeToDelete = _context.DocumentTypes.First(_ => _.TypeId== documentTypeId);
            _context.DocumentTypes.Remove(documentTypeToDelete);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DocumentType> GetDocumentTypeByIdAsync(int documentTypeId)
        {
            var result = await _context.DocumentTypes.FirstAsync(_ => _.TypeId.Equals(documentTypeId));

            return result;
        }

        public async Task<IList<DocumentType>> GetDocumentTypesAsync()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<bool> UpdateDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Update(documentType);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
