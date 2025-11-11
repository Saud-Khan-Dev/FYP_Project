using Microsoft.AspNetCore.Mvc;
using Qec_Project.Api.model;
using Qec_Project.Api.Repository;

namespace QEC_Project.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminRepository _repo;
        public AdminController(AdminRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO createAdminDto)
        {
            var res = await _repo.CreateAdmin(createAdminDto);
            if (!res.success)
            {
                ModelState.AddModelError("Error", res.message);
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);

            }

            
            return Ok(new ResponseDTO(res.success,res.message));

        }

        [HttpGet("get-admin-data")]
        public async Task<IActionResult> GetAdmin()
        {
            var res = await _repo.GetAdminData();
            return Ok(res);
        }

    }
}
