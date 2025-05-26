using Microsoft.AspNetCore.Mvc;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserScheduleController : ControllerBase
    {
        private readonly IGenericService<UserSchedule> _service;

        public UserScheduleController(IGenericService<UserSchedule> service)
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

        [HttpPost("/create")]
        public async Task<IActionResult> Create(UserSchedule entity) =>
            Ok(await _service.CreateAsync(entity));



        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<UserSchedule> schedules)
        {
            if (schedules == null || !schedules.Any())
            {
                return BadRequest("La lista de horarios está vacía.");
            }

            foreach (var schedule in schedules)
            {
                await _service.CreateAsync(schedule);
            }

            return Ok(new { message = "Horarios guardados correctamente", count = schedules.Count });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserSchedule entity)
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
