using Microsoft.AspNetCore.Mvc;
using Qec_Project.Api.model;
using QEC_Project.API.Repository;

namespace Qec_Project.Api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private SyllabusRepository _repo;
        public SyllabusController(SyllabusRepository syllabusRepository)
        {
            this._repo = syllabusRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSyllabus(string id)
        {
            var res = await this._repo.GetSyllabus(int.Parse(id));
            if (res == null)
            {
                return NotFound("There is no syllabus yet");
            }
            return Ok(res);
        }

        [HttpPost("create-syllabus")]
        public async Task<IActionResult> CreateSyllabus(SyllabusDTO syllabusDto)
        {
            var res = await this._repo.CreateSyllabus(syllabusDto);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            return Ok(new ResponseDTO(res.success, res.message));
        }

        [HttpPut("update-syllabus")]
        public async Task<IActionResult> UpdateSyllabus(SyllabusDTO syllabusDto)
        {
            var res = await this._repo.UpdateSyllabus(syllabusDto);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            return Ok(new ResponseDTO(res.success, res.message));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSyllabus(string id)
        {
            var res = await this._repo.DeleteSyllabus(id);
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
