using Microsoft.EntityFrameworkCore;

namespace Qec_Project.Api.Repository;

public class AdminRepository : IAdminRepository
{

  private DBContext _dBContext;

  public AdminRepository(DBContext dBContext)

  {
    this._dBContext = dBContext;
  }



  public async Task<(bool success, string message)> CreateAdmin(CreateAdminDTO createAdminDto)
  {
    var alreadyExisted = _dBContext.Admin.FirstOrDefault(ad => ad.Email == createAdminDto.Email);

    if (alreadyExisted != null)
    {
      return (false, "Already exist with this email");
    }

    var admin = new AdminModel()
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

    return (true, "Admin is Created Successfully");

  }

  public async Task<List<ResponseAdminDTO>> GetAdminData()
  {

    var admin = await _dBContext.Admin.ToListAsync();

    var response = admin.Select(ad => new ResponseAdminDTO()
    {
      Name = ad.Name,
      Email = ad.Email,
      PhoneNumber = ad.PhoneNumber,
      Role = ad.Role,
      Gender = ad.Gender,
      DateOfJoining = ad.DateOfJoining,
      IsActive = ad.IsActive
    }).ToList();

    return response;

  }

}
