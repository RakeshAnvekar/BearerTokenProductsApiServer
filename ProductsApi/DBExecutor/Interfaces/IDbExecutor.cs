using System.Data;

namespace ProductsApi.DBExecutor.Interfaces;

public interface IDbExecutor
{
    public Task<T> ExecuteAsync<T>(string sql,CommandType commandType,Func<IDataReader,T> mapper,CancellationToken cancellationToken,Dictionary<string,object?>? parameters=null);
}
