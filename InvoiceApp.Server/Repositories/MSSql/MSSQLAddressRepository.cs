using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Interfaces;
using InvoiceApp.Server.Repositories.MSSql.Queries.Address;
using InvoiceApp.Server.Repositories.MSSql.Queries.DocumentType;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace InvoiceApp.Server.Repositories.MSSql;

public class MSSQLAddressRepository : MSSQLBaseRepository, IAddressRepository
{
    public async Task<Address> CreateAddress(Address address)
    {
        var result = new Address();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    await command.PrepareAsync();
                    command.CommandText = AddressQueries.Create;
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                {
                    {$"@{nameof(address.City).ToUpper()}", address.City},
                    {$"@{nameof(address.Country).ToUpper()}", address.Country},
                    {$"@{nameof(address.Street).ToUpper()}", address.Street},
                    {$"@{nameof(address.Number).ToUpper()}", address.Number},
                    {$"@{nameof(address.FlatNumber).ToUpper()}", address.FlatNumber},
                    {$"@{nameof(address.PostCode).ToUpper()}", address.PostCode},
                }));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
        return result;
    }

    public async Task<bool> DeleteAddress(int addressId)
    {
        var result = false;

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    await command.PrepareAsync();
                    command.CommandText = AddressQueries.Delete;
                    command.Parameters.Add(GetParameter("@ADDRESSID", addressId));

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

    public async Task<Address> GetAddressByIdAsync(int addressId)
    {
        var result = new Address();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = AddressQueries.GetById;
                    command.Parameters.Add(GetParameter("@ADDRESSID", addressId));

                    await command.PrepareAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.AddressId = await reader.GetFieldValueAsync<int>("ADDRESSID");
                            result.City = await reader.GetFieldValueAsync<string>("CITY");
                            result.Country = await reader.GetFieldValueAsync<string>("COUNTRY");
                            result.Street = await reader.GetFieldValueAsync<string>("STREET");
                            result.Number = await reader.GetFieldValueAsync<string>("NUMBER");
                            result.FlatNumber = await reader.GetFieldValueAsync<string>("FLATNUMBER");
                            result.PostCode = await reader.GetFieldValueAsync<string>("POSTCODE");
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

    public async Task<IList<Address>> GetAddressesAsync()
    {
        var result = new List<Address>();

        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = AddressQueries.GET;

                    await command.PrepareAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new Address
                            {
                                AddressId = await reader.GetFieldValueAsync<int>("ADDRESSID"),
                                City = await reader.GetFieldValueAsync<string>("CITY"),
                                Country = await reader.GetFieldValueAsync<string>("COUNTRY"),
                                Street = await reader.GetFieldValueAsync<string>("STREET"),
                                Number = await reader.GetFieldValueAsync<string>("NUMBER"),
                                FlatNumber = await reader.GetFieldValueAsync<string>("FLATNUMBER"),
                                PostCode = await reader.GetFieldValueAsync<string>("POSTCODE"),
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

    public async Task<bool> UpdateAddress(Address address)
    {
        var result = false;
        try
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = AddressQueries.Update;
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                    {
                        {$"@{nameof(address.City).ToUpper()}", address.City},
                    {$"@{nameof(address.Country).ToUpper()}", address.Country},
                    {$"@{nameof(address.Street).ToUpper()}", address.Street},
                    {$"@{nameof(address.Number).ToUpper()}", address.Number},
                    {$"@{nameof(address.FlatNumber).ToUpper()}", address.FlatNumber},
                    {$"@{nameof(address.PostCode).ToUpper()}", address.PostCode},
                }));
                    command.Parameters.AddRange(GetParameters(new Dictionary<string, int>()
                    {
                        {$"@{nameof(address.AddressId).ToUpper()}", address.AddressId},
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
