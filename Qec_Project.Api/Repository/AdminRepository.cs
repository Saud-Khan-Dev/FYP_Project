using QEC_Project.API.Common;

namespace Qec_Project.Api.Repository;

public class AdminRepository : IAdminRepository
{

  private DBContext _dBContext;

  public AdminRepository(DBContext dBContext)

  {
    this._dBContext = dBContext;
  }



  public async Task<Result<ResponseAdminDTO>> CreateAdmin(CreateAdminDTO createAdminDto)
  {
    try
    {
      var alreadyExisted = _dBContext.Admin.FirstOrDefault(ad => ad.EmployeeId == createAdminDto.EmployeeId);

      if (alreadyExisted != null)
      {
        return Result<ResponseAdminDTO>.Failure("Admin is already present with this Id");
      }

      var newAdmin = new AdminModel()
      {
        Name = createAdminDto.Name,
        Email = createAdminDto.Email,
        PhoneNumber = createAdminDto.PhoneNumber,
        Password = createAdminDto.HashedPassword,
        Role = createAdminDto.Role,
        Gender = createAdminDto.Gender,
        DateOfJoining = createAdminDto.DateOfJoining,
        IsActive = createAdminDto.IsActive
      };
      await _dBContext.Admin.AddAsync(newAdmin);
      await _dBContext.SaveChangesAsync();

      var admin = new ResponseAdminDTO()
      {
        Id = newAdmin.Id,
        Name = newAdmin.Name,
        Email = newAdmin.Email,
        PhoneNumber = newAdmin.PhoneNumber,
        Role = newAdmin.Role,
        Gender = newAdmin.Gender,
        DateOfJoining = newAdmin.DateOfJoining,
        IsActive = newAdmin.IsActive
      };

      return Result<ResponseAdminDTO>.OK(admin);
    }
    catch (Exception e)
    {
      return Result<ResponseAdminDTO>.Failure(e.Message);

    }

  }

  public async Task<Result<ResponseAdminDTO>> GetAdminData(string id)
  {

    try
    {
      var res = await _dBContext.Admin.FindAsync(id);
      if (res == null)
      {
        return Result<ResponseAdminDTO>.Failure("Admin not found");
      }
      var admin = new ResponseAdminDTO()
      {
        Id = res.Id,
        Name = res.Name,
        Email = res.Email,
        PhoneNumber = res.PhoneNumber,
        Role = res.Role,
        Gender = res.Gender,
        DateOfJoining = res.DateOfJoining,
        IsActive = res.IsActive
      };
      return Result<ResponseAdminDTO>.OK(admin);

    }
    catch (Exception e)
    {
      return Result<ResponseAdminDTO>.Failure(e.Message);

    }




  }

}
