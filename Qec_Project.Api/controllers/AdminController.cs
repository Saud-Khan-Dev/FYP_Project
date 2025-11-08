using Microsoft.AspNetCore.Mvc;
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

            var response = new Dictionary<bool, string>()
            {
                { res.success,res.message }
            };
            return Ok(response);

        }

        [HttpGet("get-admin-data")]
        public async Task<IActionResult> GetAdmin()
        {
            var res = await _repo.GetAdminData();
            return Ok(res);
        }

    }
}
