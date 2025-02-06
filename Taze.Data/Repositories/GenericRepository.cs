using Dapper;

namespace Taze.Data.Repositories;

public class GenericRepository : IGenericRepository
{
    private readonly TazeContext _context;
    public GenericRepository(TazeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<dynamic>> GetAllAsync(string tableName)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = $"SELECT * FROM {tableName}";
            return await connection.QueryAsync(query);
        }
    }

    public async Task<dynamic> GetByIdAsync(string tableName, int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = $"SELECT * FROM {tableName} WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync(query, new { Id = id });
        }
    }

    public async Task<int> InsertAsync(string tableName, IDictionary<string, object> data)
    {
        using (var connection = _context.CreateConnection())
        {
            var columns = string.Join(", ", data.Keys);
            var parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
            var query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";
            return await connection.ExecuteAsync(query, data);
        }
    }

    public async Task<int> UpdateAsync(string tableName, int id, IDictionary<string, object> data)
    {
        using (var connection = _context.CreateConnection())
        {
            var setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
            var query = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";
            var parameters = new DynamicParameters(data);
            parameters.Add("Id", id);
            return await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<int> DeleteAsync(string tableName, int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = $"DELETE FROM {tableName} WHERE Id = @Id";
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }

    public async Task<bool> GetTableNameAsync(string tableName)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = @"SELECT TABLE_NAME 
                      FROM INFORMATION_SCHEMA.TABLES 
                      WHERE TABLE_NAME = @tableName";
            var _tableName = await connection.QueryFirstOrDefaultAsync<string>(query, new { tableName = tableName });
            if (string.IsNullOrEmpty(_tableName))
                return false;
            return true;
        }
    }
}