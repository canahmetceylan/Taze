using Taze.Business.Abstract;
using Taze.Data.Repositories;

namespace Taze.Business.Concrete;

public class ContentManager : IContentService
{
    private readonly IGenericRepository _repository;
  
    public ContentManager(IGenericRepository repository)
    {
        _repository = repository;
    }

    private async Task<string> GetTableNameAsync(string contentType)
    {
        var flag = await _repository.GetTableNameAsync(contentType);
        if (flag)
            return contentType;
        else
            throw new Exception("Tablo ismi bulunamadı.");
    }

    public async Task<IEnumerable<dynamic>> GetAllAsync(string contentType)
    {
        var tableName = await GetTableNameAsync(contentType);
        return await _repository.GetAllAsync(tableName);
    }

    public async Task<dynamic> GetByIdAsync(string contentType, int id)
    {
        var tableName = await GetTableNameAsync(contentType);
        return await _repository.GetByIdAsync(tableName, id);
    }

    public async Task<int> InsertAsync(string contentType, IDictionary<string, object> data)
    {
        var tableName = await GetTableNameAsync(contentType);
        return await _repository.InsertAsync(tableName, data);
    }

    public async Task<int> UpdateAsync(string contentType, int id, IDictionary<string, object> data)
    {
        var tableName = await GetTableNameAsync(contentType);
        return await _repository.UpdateAsync(tableName, id, data);
    }

    public async Task<int> DeleteAsync(string contentType, int id)
    {
        var tableName = await GetTableNameAsync(contentType);
        return await _repository.DeleteAsync(tableName, id);
    }
}
