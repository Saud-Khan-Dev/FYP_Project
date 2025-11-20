using Microsoft.EntityFrameworkCore;
using QEC_Project.API.Common;
using Qec_Project.Api.model;
using QEC_Project.API.DTOs;

namespace QEC_Project.API.Repository
{
  public class FacultyRepository : IFacultyRepository

  {
    private DBContext _dBContext;

    public FacultyRepository(DBContext dBContext)
    {
      this._dBContext = dBContext;
    }

    public async Task<Result<ResponseFacultyDTO>> CreateFaculty(FacultyDTO dto)
    {
      var alreadyExist = await this._dBContext.Faculty.FindAsync(dto.EmployeeId);
      if (alreadyExist != null)
      {
        return Result<ResponseFacultyDTO>.Failure("Faculty is already present with this employee Id");
      }
      var faculty = new FacultyModel
      {
        Name = dto.Name,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        Role = "Faculty", // optional default
        Gender = dto.Gender,
        DateOfJoining = dto.DateOfJoining,
        IsActive = true,

        EmployeeId = dto.EmployeeId,
        Department = dto.Department,
        Designation = dto.Designation,
      };


      await _dBContext.Faculty.AddAsync(faculty);
      await _dBContext.SaveChangesAsync();

      var facultyRes = new ResponseFacultyDTO()
      {
        Name = faculty.Name,
        Email = faculty.Email,
        PhoneNumber = faculty.PhoneNumber,
        Role = faculty.Role,
        Gender = faculty.Gender,
        DateOfJoining = faculty.DateOfJoining,
        IsActive = true,
        EmployeeId = faculty.EmployeeId,
        Department = faculty.Department,
        Designation = faculty.Designation,
      };

      return Result<ResponseFacultyDTO>.OK(facultyRes);
    }

    public async Task<List<ResponseFacultyDTO>> GetAllFaculty()
    {
      var faculties = await this._dBContext.Faculty.ToListAsync();
      if (!faculties.Any())
      {
        return new List<ResponseFacultyDTO>();
      }

      var fac = faculties.Select(f => new ResponseFacultyDTO()
      {
        Id = f.Id,
        Name = f.Name,
        Email = f.Email,
        PhoneNumber = f.PhoneNumber,
        Gender = f.Gender,
        Department = f.Department,
        Designation = f.Designation,
        EmployeeId = f.EmployeeId,
        DateOfJoining = f.DateOfJoining,
        IsActive = f.IsActive
      }).ToList();



      return fac;
    }

    public async Task<Result<ResponseFacultyDTO>> GetSpecificFaculty(string empId)
    {
      var faculty = await _dBContext.Faculty
          .FirstOrDefaultAsync(f => f.EmployeeId == empId);

      if (faculty == null)
      {
        return Result<ResponseFacultyDTO>.Failure("Faculty not found with this Employee ID.");
      }

      var dto = new ResponseFacultyDTO
      {
        Id = faculty.Id,
        Name = faculty.Name,
        Email = faculty.Email,
        PhoneNumber = faculty.PhoneNumber,
        Gender = faculty.Gender,
        Department = faculty.Department,
        Designation = faculty.Designation,
        EmployeeId = faculty.EmployeeId,
        DateOfJoining = faculty.DateOfJoining,
        IsActive = faculty.IsActive
      };

      return Result<ResponseFacultyDTO>.OK(dto);
    }


    public async Task<ResponseDTO> UpdateFacultyInfo(UpdateFacultyDTO dto)
    {
      // 1. Find the faculty
      var faculty = await _dBContext.Faculty
         .FirstOrDefaultAsync(f => f.EmployeeId == dto.EmployeeId);

      if (faculty == null)
      {
        return new ResponseDTO(false, "Employee does not found");
      }

      faculty.Name = dto.Name;
      faculty.Email = dto.Email;
      faculty.PhoneNumber = dto.PhoneNumber;
      faculty.Password = dto.Password;
      faculty.Role = dto.Role;
      faculty.Gender = dto.Gender;
      faculty.DateOfJoining = dto.DateOfJoining;
      faculty.IsActive = dto.IsActive;
      faculty.Department = dto.Department;
      faculty.Designation = dto.Designation;
       
      _dBContext.Faculty.Update(faculty);
      await _dBContext.SaveChangesAsync();

      return new ResponseDTO(true, "Faculty information updated successfully");
    }
    public async Task<ResponseDTO> DeleteFaculty(string empId)
    {
      var faculty = await _dBContext.Faculty
         .FirstOrDefaultAsync(e => e.EmployeeId == empId);

      if (faculty == null)
      {
        return new ResponseDTO(false, "Employee does not found");
      }
      _dBContext.Faculty.Remove(faculty);
      await _dBContext.SaveChangesAsync();

      return new ResponseDTO(true, "Faculty information deleted successfully");
    }
  }
}

