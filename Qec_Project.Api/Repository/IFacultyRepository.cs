using QEC_Project.API.Common;
using Qec_Project.Api.model;

namespace QEC_Project.API.DTOs
{


  public interface IFacultyRepository
  {
    public Task<Result<ResponseFacultyDTO>> CreateFaculty(FacultyDTO dto);
    public Task<List<ResponseFacultyDTO>> GetAllFaculty();
    public Task<Result<ResponseFacultyDTO>> GetSpecificFaculty(string empId);
    public Task<ResponseDTO> UpdateFacultyInfo(UpdateFacultyDTO dto);
    public Task<ResponseDTO> DeleteFaculty(string empId);

  }
}