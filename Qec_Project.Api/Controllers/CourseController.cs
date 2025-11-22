using Microsoft.AspNetCore.Mvc;
using Qec_Project.Api.model;
using Qec_Project.Api.Repository;

namespace QEC_Project.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseRepository _courseRepository;
        public CourseController(CourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GgetCourses()
        {

            var res = await this._courseRepository.GetAllCourse();

            return Ok(res);
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> CreateCourse(CourseModel courseModel)
        {
            var res = await this._courseRepository.CreateCourse(courseModel);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            return Ok(new ResponseDTO(res.success, res.message));

        }

        [HttpGet("{courseCode}")]
        public async Task<IActionResult> GetSpecificCourse(string courseCode)
        {
            var res = await this._courseRepository.GetSpecificCourse(courseCode);
            if (!res.Success)
            {
                ModelState.AddModelError("Error", "Course not found");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            return Ok(res);

        }

        [HttpPut("{courseCode}")]
        public async Task<IActionResult> UpdateCourse(CourseModel courseModel)
        {
            var res = await this._courseRepository.UpdateCourse(courseModel);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }
            return Ok(new ResponseDTO(res.success, res.message));
        }

        [HttpDelete("{courseCode}")]
        public async Task<IActionResult> DeleteCourse(string courseCode)
        {
            var res = await this._courseRepository.DeleteCourse(courseCode);
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
