using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApiBackPruebaTec.Entities.Models;
using ApiBackPruebaTec.Entities.Models.DTOs;

namespace ApiBackPruebaTec.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DbpruebaTecContext _dbContext;
        public TaskController(DbpruebaTecContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("TaskList")]
        public async Task<IActionResult> TaskList()
        {
            var taskList = await _dbContext.Tasks.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new
            {
                value = taskList
            });
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(TaskDTO task)
        {
            var taskModel = new Entities.Models.Task
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = DateTime.Now
            };

            await _dbContext.Tasks.AddAsync(taskModel);
            await _dbContext.SaveChangesAsync();
            if(taskModel.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDTO task)
        {
            var taskModel = new Entities.Models.Task
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = DateTime.Now
            };

            var taskUp = _dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id);

            if (taskUp != null)
            {
                taskUp.Title = task.Title;
                taskUp.Description = task.Description;
                taskUp.Status = task.Status;
                taskUp.CreatedAt = DateTime.Now;
            }

            await _dbContext.SaveChangesAsync();
            if (taskModel.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {

            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
            }

            await _dbContext.SaveChangesAsync();
            if (task.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }
    }
}
