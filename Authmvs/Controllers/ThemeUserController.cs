using Microsoft.AspNetCore.Mvc;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ThemeUserController : ControllerBase
    {
        private readonly IGenericService<ThemeUser> _service;

        public ThemeUserController(IGenericService<ThemeUser> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ThemeUser entity) => Ok(await _service.CreateAsync(entity));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ThemeUser entity)
        {
            var result = await _service.UpdateAsync(id, entity);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }

}