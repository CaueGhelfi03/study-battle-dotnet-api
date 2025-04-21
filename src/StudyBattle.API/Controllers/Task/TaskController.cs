using Microsoft.AspNetCore.Mvc;
using StudyBattle.API.Services.Interfaces.Task;
using System.ComponentModel.DataAnnotations;
using TaskSystem.Core.Domain.DTOs.TaskDTO;

namespace StudyBattle.API.Controllers.Task
{

    [ApiController]
    [Route("/api/[controller]")]
    public class TaskController(ITaskService service) : Controller
    {
        [HttpPost]
        public async Task<ActionResult<TaskResponseDTO>> CreateTask([FromQuery]Guid ChallengeId, [FromBody] TaskCreateDTO taskCreate)
        {
            try
            {
                var createdTask = await service.AddTaskToChallengeAsync(taskCreate,ChallengeId);
                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{TaskId}")]
        public async Task<ActionResult<bool?>> DeleteTask([FromRoute][Required] Guid TaskId)
        {
            try
            {
                await service.DeleteAsync(TaskId);
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("{TaskId}")]
        public async Task<ActionResult<TaskResponseDTO>> GetTaskById([FromRoute][Required] Guid TaskId)
        {
            try
            {
                var user = await service.GetByIdAsync(TaskId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("tasks-by-challenge/{ChallengeId}")]
        public async Task<ActionResult<ICollection<TaskResponseDTO>>> GetTasksByChallengeId([FromRoute][Required]Guid ChallengeId)
        {
            try
            {
                var tasks = await service.GetTaskByChallengeId(ChallengeId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");

            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TaskResponseDTO>>> GetAllTasks()
        {
            try
            {
                var tasks = await service.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<ActionResult<TaskResponseDTO>> UpdateTaskAsync([FromQuery]Guid TaskId, [FromBody]TaskUpdateDTO TaskUpdateDTO)
        {
            var tasks = await service.UpdateAsync(TaskId, TaskUpdateDTO);
            return Ok(tasks);
        }
    }
}
