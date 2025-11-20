using Microsoft.AspNetCore.Mvc;
using QEC_Project.API.DTOs;
using QEC_Project.API.Services;

namespace Qec_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private FacultyService _service;
        public FacultyController(FacultyService service)
        {
            this._service = service;
        }

        [HttpPost("create-faculty")]
        public async Task<IActionResult> CreateFaculty(FacultyDTO dto)
        {
            var res = await this._service.CreateFaculty(dto);
            if (!res.Success)
            {
                ModelState.AddModelError("Error", res.Message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);

        }

        [HttpGet("get-all-faculty")]

        public async Task<IActionResult> GetAllFaculty()
        {
            var res = await this._service.GetAllFaculty();
            return Ok(res);
        }

        [HttpGet("{empId}")]
        public async Task<IActionResult> GetSpecificFaculty(string empId)
        {
            var res = await this._service.GetSpecificFaculty(empId);
            if (!res.Success)
            {
                ModelState.AddModelError("Error", res.Message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);
        }

        [HttpPut("update-faculty-info")]
        public async Task<IActionResult> UpdateFacultyInfo(UpdateFacultyDTO dto)
        {
            var res = await this._service.UpdateFacultyInfo(dto);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);
        }

        [HttpDelete("{empId}")]
        public async Task<IActionResult> DeleteFaculty(string empId)
        {
            var res = await this._service.DeleteFaculty(empId);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validate = new ValidationProblemDetails(ModelState);
                return BadRequest(validate);
            }
            return Ok(res);

        }

    }
}
