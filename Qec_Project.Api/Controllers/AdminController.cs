using Microsoft.AspNetCore.Mvc;

using QEC_Project.API.Services;

namespace QEC_Project.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _service;
        public AdminController(AdminService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO createAdminDto)
        {
            var res = await _service.CreateAdmin(createAdminDto);
            if (!res.Success)
            {
                ModelState.AddModelError("Error", res.Message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }


            return Ok(res);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(string id)
        {
            var res = await _service.GetAdmin(id);
            if (!res.Success)
            {
                ModelState.AddModelError("Error", res.Message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            return Ok(res);
        }

    }
}
