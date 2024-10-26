using ProductsApi.DBExecutor.Interfaces;
using System.Data;
using System.Diagnostics;

namespace ProductsApi.DBExecutor;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ProductsApi.Models.ConnectionOption;

public class DbExecutor : IDbExecutor
{
    private readonly ILogger<DbExecutor> _logger;
    private readonly ConnectionOption _connectionOption;
    public DbExecutor(ILogger<DbExecutor> logger, IOptions<ConnectionOption> connectionOption)
    {
        _logger = logger;
        _connectionOption=connectionOption.Value;
    }
    public async Task<T> ExecuteAsync<T>(string sql, CommandType commandType, Func<IDataReader, T> mapper, CancellationToken cancellationToken, Dictionary<string, object?>? parameters = null)
    {
        try
        {
            var stopWatch = Stopwatch.StartNew;
            await using var connection = new SqlConnection(_connectionOption.ConnectionString);
            await using var command= connection.CreateCommand();
            await connection.OpenAsync();
            command.CommandText = sql;
            command.CommandType = commandType;
            command.CommandTimeout = 60 * 30;
            if (parameters!=null)
            {
                foreach (var key in parameters.Keys) {
                    command.Parameters.AddWithValue(key, parameters[key] == null ? DBNull.Value : parameters[key]);
                }
            }  
            var reader= await command.ExecuteReaderAsync(cancellationToken);
            var result = mapper(reader);
            await connection.CloseAsync();
            return result;
        }
        catch (Exception ex) {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("Opartion is cancelled by user :",ex,cancellationToken);
            }
            _logger.LogError(ex, "SQL Server read query error");
            throw;
        }       
    }
}
