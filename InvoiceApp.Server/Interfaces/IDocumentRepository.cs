using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IDocumentRepository
{
    Task<IList<Document>> GetDocumentsAsync();
    Task<Document> GetDocumentByIdAsync(int DocumentId);
    Task<Document> CreateDocument(Document Document);
    Task<bool> UpdateDocument(Document Document);
    Task<bool> DeleteDocument(int DocumentId);
}
