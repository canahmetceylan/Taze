namespace Taze.Data.Repositories;

public interface IGenericRepository
{
    Task<IEnumerable<dynamic>> GetAllAsync(string tableName);
    Task<dynamic> GetByIdAsync(string tableName, int id);
    Task<int> InsertAsync(string tableName, IDictionary<string, object> data);
    Task<int> UpdateAsync(string tableName, int id, IDictionary<string, object> data);
    Task<int> DeleteAsync(string tableName, int id);
    Task<bool> GetTableNameAsync(string tableName);
}
