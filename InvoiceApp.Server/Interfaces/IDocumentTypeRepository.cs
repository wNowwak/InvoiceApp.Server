using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IDocumentTypeRepository
{
    Task<IList<DocumentType>> GetDocumentTypesAsync();
    Task<DocumentType> GetDocumentTypeByIdAsync(int documentTypeId);
    Task<DocumentType> CreateDocumentType(DocumentType documentType);
    Task<DocumentType> UpdateDocumentType(DocumentType documentType);
    Task<bool> DeleteDocumentType(int documentTypeId);
}
