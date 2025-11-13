using Qec_Project.Api.Repository;
using QEC_Project.API.Common;

namespace QEC_Project.API.Services

{
  public class AdminService
  {
    private readonly AdminRepository _repo;
    public AdminService(AdminRepository repo)
    {
      this._repo = repo;
    }

    public async Task<Result<ResponseAdminDTO>> CreateAdmin(CreateAdminDTO createAdminDto)
    {
      var res = await this._repo.CreateAdmin(createAdminDto);
      if (!res.Success)
      {
        return Result<ResponseAdminDTO>.Failure(res.Message);
      }
      var admin = new ResponseAdminDTO()
      {
        Id = res.Value.Id,
        Name = res.Value.Name,
        Email = res.Value.Email,
        PhoneNumber = res.Value.PhoneNumber,
        Role = res.Value.Role,
        Gender = res.Value.Gender,
        DateOfJoining = res.Value.DateOfJoining,
        IsActive = res.Value.IsActive
      };
      return Result<ResponseAdminDTO>.OK(admin);

    }



    public async Task<Result<ResponseAdminDTO>> GetAdmin(string id)
    {
      var res = await this._repo.GetAdminData(id);
      if (!res.Success)
      {
        return Result<ResponseAdminDTO>.Failure(res.Message);
      }
      var admin = new ResponseAdminDTO()
      {
        Id = res.Value.Id,
        Name = res.Value.Name,
        Email = res.Value.Email,
        PhoneNumber = res.Value.PhoneNumber,
        Role = res.Value.Role,
        Gender = res.Value.Gender,
        DateOfJoining = res.Value.DateOfJoining,
        IsActive = res.Value.IsActive
      };
      return Result<ResponseAdminDTO>.OK(admin);
    }
  }
}