using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QEC_Project.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DBContext _dBContext;
        public AdminController(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
      public async Task<List<ResponseAdminDTO>> GetAdmins()
{
    var admins = await _dBContext.Admin.ToListAsync();

    var response = admins.Select(a => new ResponseAdminDTO
    {
        Name = a.Name,
        Email = a.Email,
        PhoneNumber = a.PhoneNumber,
        Role = a.Role,
        Gender = a.Gender,
        DateOfJoining = a.DateOfJoining,
        IsActive = a.IsActive
    }).ToList();

    return response;
}

        [HttpPost]
        public async Task <IActionResult> CreateAdmin(CreateAdminDTO createAdminDto)
        {
            var otherUser = _dBContext.Admin.FirstOrDefault(a => a.Email == createAdminDto.Email);

            if (otherUser != null)
            {
                ModelState.AddModelError("Email", "Admin with this email is already Present in Databse");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var admin = new AdminModel
            {
                Name = createAdminDto.Name,
                Email = createAdminDto.Email,
                PhoneNumber = createAdminDto.PhoneNumber,
                PasswordHash = createAdminDto.HashedPassword,
                Role = createAdminDto.Role,
                Gender = createAdminDto.Gender,
                DateOfJoining = createAdminDto.DateOfJoining,
                IsActive = createAdminDto.IsActive
            };
            await _dBContext.Admin.AddAsync(admin);
            await _dBContext.SaveChangesAsync();
            return Ok();

        }

    }
}
