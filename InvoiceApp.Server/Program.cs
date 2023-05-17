using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Repositories.MSSql;

var repo = new MSSQLDocumentTypeRepository();

var documentType = new DocumentType
{
    Name = "Test",
    Shortcut = "TestShort",
};

//await repo.CreateDocumentType(documentType);
//await repo.DeleteDocumentType(3);
await repo.GetDocumentTypeByIdAsync(4);