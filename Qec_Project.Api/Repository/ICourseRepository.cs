using Qec_Project.Api.model;

namespace Qec_Project.Api.Repository;

public interface ICourseRepository
{
  public  Task<ResponseDTO> CreateCourse(CourseModel courseModel);
  public Task<List<CourseModel>> GetAllCourse();
  public Task<CourseDTO> GetSpecificCourse(string courseCode);
  public Task<ResponseDTO> UpdateCourse(CourseModel courseModel );
  public Task<ResponseDTO> DeleteCourse(string courseCode);


}
