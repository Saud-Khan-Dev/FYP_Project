using Microsoft.AspNetCore.Mvc;
using Qec_Project.Api.model;
using QEC_Project.API.Repository;

namespace Qec_Project.Api.controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeachingWeeklyScheduleController : ControllerBase
  {
    private TeachingWeeklyScheduleRepository _repo;
    public TeachingWeeklyScheduleController(TeachingWeeklyScheduleRepository repository)
    {
      this._repo = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSchedule(string id)
    {
      var res = await this._repo.GetSchedule(id);
      if (res == null)
      {
        return NotFound("No schedule");
      }
      return Ok(res);
    }

    [HttpPost("create-schedule")]
    public async Task<IActionResult> CreateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto)
    {
      var res = await this._repo.CreateSchedule(teachingWeeklyScheduleDto);
      if (!res.success)
      {
        ModelState.AddModelError("Error", res.message);
        var validation = new ValidationProblemDetails(ModelState);
        return BadRequest(validation);
      }
      return Ok(new ResponseDTO(res.success, res.message));
    }

    [HttpPut("create-schedule")]
    public async Task<IActionResult> UpdateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto)
    {
      var res = await this._repo.CreateSchedule(teachingWeeklyScheduleDto);
      if (!res.success)
      {
        ModelState.AddModelError("Error", res.message);
        var validation = new ValidationProblemDetails(ModelState);
        return BadRequest(validation);
      }
      return Ok(new ResponseDTO(res.success, res.message));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchedule(string id)
    {
      var res = await this._repo.DeleteSchedule(id);
      if (!res.success)
      {
        ModelState.AddModelError("Error", res.message);
        var validation = new ValidationProblemDetails(ModelState);
        return BadRequest(validation);
      }
      return Ok(new ResponseDTO(res.success, res.message));

    }
  }
}

