using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Taze.Data;

public class TazeContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public TazeContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
