﻿using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Interfaces;
using InvoiceApp.Server.Repositories.MSSql.Queries.DocumentType;
using System.Data;

namespace InvoiceApp.Server.Repositories.MSSql;

internal class MSSQLDocumentTypeRepository : MSSQLBaseRepository, IDocumentTypeRepository
{
    public async Task<DocumentType> CreateDocumentType(DocumentType documentType)
    {
        var result = new DocumentType();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    await command.PrepareAsync();
                    command.CommandText = DocumentTypeQueries.Create;
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                {
                    {$"@{nameof(documentType.Name).ToUpper()}", documentType.Name},
                    {$"@{nameof(documentType.Shortcut).ToUpper()}", documentType.Shortcut},
                }));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<bool> DeleteDocumentType(int documentTypeId)
    {
        var result = false;

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    await command.PrepareAsync();
                    command.CommandText = DocumentTypeQueries.Delete;
                    command.Parameters.Add(GetParameter("@TYPEID", documentTypeId));

                    result = (await command.ExecuteNonQueryAsync()) > 0;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<DocumentType> GetDocumentTypeByIdAsync(int documentTypeId)
    {
        var result = new DocumentType();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = DocumentTypeQueries.GetById;
                    command.Parameters.Add(GetParameter("@TYPEID", documentTypeId));

                    await command.PrepareAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.TypeId = await reader.GetFieldValueAsync<int>("TYPEID");
                            result.Name = await reader.GetFieldValueAsync<string>("NAME");
                            result.Shortcut = await reader.GetFieldValueAsync<string>("SHORTCUT");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<IList<DocumentType>> GetDocumentTypesAsync()
    {
        var result = new List<DocumentType>();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = DocumentTypeQueries.Get;

                    await command.PrepareAsync();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new DocumentType
                            {
                                TypeId = reader.GetFieldValue<int>("TYPEID"),
                                Name = reader.GetFieldValue<string>("NAME"),
                                Shortcut = reader.GetFieldValue<string>("SHORTCUT"),
                            });
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }

    public async Task<bool> UpdateDocumentType(DocumentType documentType)
    {
        var result = false;
        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = DocumentTypeQueries.Update;
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                {
                    {$"@{nameof(documentType.Name).ToUpper()}", documentType.Name},
                    {$"@{nameof(documentType.Shortcut).ToUpper()}", documentType.Shortcut}
                }));
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, int>()
                {
                    {$"@{nameof(documentType.TypeId).ToUpper()}", documentType.TypeId},
                }));
                    await command.PrepareAsync();
                    result = (await command.ExecuteNonQueryAsync()) > 0;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return result;
    }
}
