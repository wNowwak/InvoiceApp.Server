using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace InvoiceApp.Server.Repositories.MSSql;

public abstract class MSSQLBaseRepository
{
    private SqlConnection _sqlConnection = default!;

    public MSSQLBaseRepository()
    {
        _sqlConnection = new SqlConnection();
        var connectionStringBuilder = new SqlConnectionStringBuilder();
        connectionStringBuilder.DataSource = @"PIEC\DEVSERVER";
        connectionStringBuilder.InitialCatalog = "masterThesis";
        connectionStringBuilder.IntegratedSecurity = true;
        _sqlConnection.ConnectionString = connectionStringBuilder.ConnectionString;
    }

    protected SqlConnection GetSqlConnection()
    {
        if (_sqlConnection.State == ConnectionState.Closed)
            _sqlConnection.Open();
        return _sqlConnection;
    }

    protected SqlParameter GetParameter<T>(string name, T value)
    {
        var result = new SqlParameter
        {
            ParameterName = name,
            Value = value
        };

        if(typeof(T) == typeof(string))
        {
            result.Size = 255;
            result.DbType = DbType.String;
        }else if(typeof(T) == typeof(int))
        {
            result.DbType = DbType.Int32;
        }else if(typeof(T) == typeof(decimal))
        {
            result.DbType = DbType.Decimal;
        }

        return result;
    }

    protected SqlParameter[] GetParameters<T>(IDictionary<string, T> parameters)
    {
        var result = new List<SqlParameter>();

        foreach (var parameter in parameters)
        {
            result.Add(GetParameter(parameter.Key, parameter.Value));
        }

        return result.ToArray();
    }
}
