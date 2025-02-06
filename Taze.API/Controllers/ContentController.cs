using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taze.Business.Abstract;

namespace Taze.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        // Listeleme (GET: api/content/yazilar)
        [HttpGet]
        public async Task<IActionResult> GetAll(string contentType)
        {
            var result = await _contentService.GetAllAsync(contentType);
            return Ok(result);
        }

        // Detay (GET: api/content/yazilar/1)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string contentType, int id)
        {
            var result = await _contentService.GetByIdAsync(contentType, id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Ekleme (POST: api/content/kategoriler)
        [HttpPost]
        public async Task<IActionResult> Insert(string contentType, [FromBody] Dictionary<string, object> data)
        {
            var affectedRows = await _contentService.InsertAsync(contentType, data);
            return Ok(new { affectedRows });
        }

        // Güncelleme (PUT: api/content/kategoriler/1)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string contentType, int id, [FromBody] Dictionary<string, object> data)
        {
            var affectedRows = await _contentService.UpdateAsync(contentType, id, data);
            return Ok(new { affectedRows });
        }

        // Silme (DELETE: api/content/kategoriler/1)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string contentType, int id)
        {
            var affectedRows = await _contentService.DeleteAsync(contentType, id);
            return Ok(new { affectedRows });
        }
    }
}
