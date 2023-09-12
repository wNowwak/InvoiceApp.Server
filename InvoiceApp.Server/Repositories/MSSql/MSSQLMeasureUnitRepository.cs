using InvoiceApp.Commons.Models;
using InvoiceApp.Server.Interfaces;
using InvoiceApp.Server.Repositories.MSSql.Queries.DocumentType;
using InvoiceApp.Server.Repositories.MSSql.Queries.MeasureUnit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvoiceApp.Server.Repositories.MSSql
{
    internal class MSSQLMeasureUnitRepository : MSSQLBaseRepository, IMeasureUnitRepository
    {
        public async Task<MeasureUnit> CreateMeasureUnit(MeasureUnit measureUnit)
        {
            var result = new MeasureUnit();

            try
            {
                using (var connection = GetSqlConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        await command.PrepareAsync();
                        command.CommandText = MeasureUnitQueries.Create;
                        command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                        {
                            {$"@{nameof(measureUnit.Name).ToUpper()}", measureUnit.Name},
                    {$"@{nameof(measureUnit.Shortcut).ToUpper()}", measureUnit.Shortcut},
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

        public async Task<bool> DeleteMeasureUnit(int measureUnitId)
        {
            var result = false;

            try
            {
                using (var connection = GetSqlConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        await command.PrepareAsync();
                        command.CommandText = MeasureUnitQueries.Delete;
                        command.Parameters.Add(GetParameter("@MEASUREUNITID", measureUnitId));

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

        public async Task<MeasureUnit> GetMeasureUnitByIdAsync(int measureUnitId)
        {
            var result = new MeasureUnit();

            try
            {
                using (var connection = GetSqlConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = MeasureUnitQueries.GetById;
                        command.Parameters.Add(GetParameter("@MEASUREUNITID", measureUnitId));

                        await command.PrepareAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                result.MeasureUnitId = await reader.GetFieldValueAsync<int>("MeasureUnitId".ToUpper());
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

        public async Task<IList<MeasureUnit>> GetMeasureUnitsAsync()
        {
            var result = new List<MeasureUnit>();

            try
            {
                using (var connection = GetSqlConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = MeasureUnitQueries.Get;

                        await command.PrepareAsync();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new MeasureUnit
                                {
                                    MeasureUnitId = reader.GetFieldValue<int>("MeasureUnitId".ToUpper()),
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

        public async Task<bool> UpdateMeasureUnit(MeasureUnit measureUnit)
        {
            var result = false;
            try
            {
                using (var connection = GetSqlConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = MeasureUnitQueries.Update;
                        command.Parameters.AddRange(GetParameters(new Dictionary<string, string>()
                {
                    {$"@{nameof(measureUnit.Name).ToUpper()}", measureUnit.Name},
                    {$"@{nameof(measureUnit.Shortcut).ToUpper()}", measureUnit.Shortcut}
                }));
                        command.Parameters.AddRange(GetParameters(new Dictionary<string, int>()
                {
                    {$"@{nameof(measureUnit.MeasureUnitId).ToUpper()}", measureUnit.MeasureUnitId},
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
}
