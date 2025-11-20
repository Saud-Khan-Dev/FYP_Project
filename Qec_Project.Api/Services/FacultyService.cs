using QEC_Project.API.Common;
using QEC_Project.API.DTOs;
using Qec_Project.Api.model;
using QEC_Project.API.Repository;

namespace QEC_Project.API.Services
{

  public class FacultyService
  {
    private FacultyRepository _repo;
    public FacultyService(FacultyRepository repo)
    {
      this._repo = repo;
    }

    public async Task<Result<ResponseFacultyDTO>> CreateFaculty(FacultyDTO dto)
    {
      var hashespassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
      var faculty = new FacultyDTO()
      {
        EmployeeId = dto.EmployeeId,
        Department = dto.Department,
        Designation = dto.Designation,
        DateOfJoining = dto.DateOfJoining,
        Email = dto.Email,
        Gender = dto.Gender,
        IsActive = dto.IsActive,
        Name = dto.Name,
        Password = hashespassword,
        PhoneNumber = dto.PhoneNumber,
        Role = dto.Role
      };
      var res = await this._repo.CreateFaculty(faculty);
      return res;
    }

    public async Task<Result<ResponseFacultyDTO>> GetSpecificFaculty(string empId)
    {
      var res = await this._repo.GetSpecificFaculty(empId);
      return res;
    }
    public async Task<List<ResponseFacultyDTO>> GetAllFaculty()
    {
      var res = await this._repo.GetAllFaculty();
      return res;
    }
    public async Task<ResponseDTO> UpdateFacultyInfo(UpdateFacultyDTO dto)
    {
      var hashespassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
      var faculty = new UpdateFacultyDTO()
      {
        Name = dto.Name,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        Password = hashespassword,
        Role = dto.Role,
        Gender = dto.Gender,
        DateOfJoining = dto.DateOfJoining,
        IsActive = dto.IsActive,
        Department = dto.Department,
        Designation = dto.Designation,
      };
      return await this._repo.UpdateFacultyInfo(faculty);
    }
    public async Task<ResponseDTO> DeleteFaculty(string empId)
    {
      return await this._repo.DeleteFaculty(empId);
    }



  }

}