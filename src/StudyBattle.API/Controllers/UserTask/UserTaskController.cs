using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;
using StudyBattle.API.Services.Interfaces.UserTaskCompletation;
using StudyBattle.API.Services.UserTaskCompletation;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;

namespace StudyBattle.API.Controllers.UserTask
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserTaskController : Controller
    {
        private readonly IUserTaskService _service;
        public UserTaskController(IUserTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserTaskResponseDTO>> AddUserCompletation([FromBody] UserTaskCreateDTO userTask)
        {
            return await _service.AddUserCompletation(userTask);
        }

        [HttpGet]
        [Route("all-tasks-completation/user")]
        public async Task<ActionResult<UserAllTasksDTO>> GetAllTaskCompletationByUser([FromQuery] Guid UserId)
        {
            return await _service.GetAllTaskCompletationByUser(UserId);
        }
    }
}
