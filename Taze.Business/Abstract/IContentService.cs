using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taze.Business.Abstract;

public interface IContentService
{
    Task<IEnumerable<dynamic>> GetAllAsync(string contentType);
    Task<dynamic> GetByIdAsync(string contentType, int id);
    Task<int> InsertAsync(string contentType, IDictionary<string, object> data);
    Task<int> UpdateAsync(string contentType, int id, IDictionary<string, object> data);
    Task<int> DeleteAsync(string contentType, int id);
}
