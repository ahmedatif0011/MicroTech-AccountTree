using System.Data;

namespace MicroTech.Infrastructure.Interfaces.Dapper
{
    public interface IApplicationWriteDbConnection : IApplicationReadDbConnection
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null);
    }
}
