using Qec_Project.Api.model;
using QEC_Project.API.Common;

namespace Qec_Project.Api.Repository;

public interface ICourseRepository
{
  public  Task<ResponseDTO> CreateCourse(CourseModel courseModel);
  public Task<Result<List<CourseModel>>> GetAllCourse();
  public Task<Result<CourseDTO>> GetSpecificCourse(string courseCode);
  public Task<ResponseDTO> UpdateCourse(CourseModel courseModel );
  public Task<ResponseDTO> DeleteCourse(string courseCode);


}
