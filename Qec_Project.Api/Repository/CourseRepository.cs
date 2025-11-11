using Microsoft.EntityFrameworkCore;
using Qec_Project.Api.model;

namespace Qec_Project.Api.Repository;

public class CourseRepository : ICourseRepository
{

  private DBContext _dbContext;

  public CourseRepository(DBContext dBContext)
  {
    this._dbContext = dBContext;
  }
  public async Task<ResponseDTO> CreateCourse(CourseModel courseModel)
  {
    var alreadyExistCourse =
      await this._dbContext.Course.FirstOrDefaultAsync(ac => ac.CourseCode == courseModel.CourseCode);
    if (alreadyExistCourse != null)
    {
      return new ResponseDTO(false, "This course already exist with the given Course Code");
    }

    var course = new CourseModel()
    {
      CourseCode = courseModel.CourseCode,
      Description = courseModel.Description,
      TheoreyCreditHours = courseModel.TheoreyCreditHours,
      LabCreditHours = courseModel.LabCreditHours,
      IsActive = courseModel.IsActive
    };
    await _dbContext.Course.AddAsync(course);
    await _dbContext.SaveChangesAsync();

    return new ResponseDTO(true, "Course is created Successfully");
  }

  public async Task<List<CourseModel>> GetAllCourse()
  {
    var courses = await this._dbContext.Course.ToListAsync();
    var response = courses.Select(c => new CourseModel()
    {
      CourseCode = c.CourseCode,
      Description = c.Description,
      TheoreyCreditHours = c.TheoreyCreditHours,
      LabCreditHours = c.LabCreditHours,
      IsActive = c.IsActive
    }).ToList();
    return response;
  }

  public async Task<CourseDTO> GetSpecificCourse(string courseCode)
  {
    var course = await this._dbContext.Course.FindAsync(courseCode);
    if (course == null)
    {
      return null;
    }

    return new CourseDTO(course.CourseCode, course.Description, course.TheoreyCreditHours, course.LabCreditHours, course.IsActive);
  }

  public async Task<ResponseDTO> UpdateCourse(CourseModel courseModel)
  {
    var existingCourse = await this.GetSpecificCourse(courseModel.CourseCode);
    if (existingCourse == null)
    {
      return new ResponseDTO(false, "Course Not found");
    }

    existingCourse.CourseCode = courseModel.CourseCode;
    existingCourse.Description = courseModel.Description;
    existingCourse.TheoreyCreditHours = courseModel.TheoreyCreditHours;
    existingCourse.LabCreditHours = courseModel.LabCreditHours;
    existingCourse.IsActive = courseModel.IsActive;
    await this._dbContext.SaveChangesAsync();
    return new ResponseDTO(true, "Course updated successfully");
  }

  public async Task<ResponseDTO> DeleteCourse(string courseCode)
  {
    var existingCourse = await this._dbContext.Course.FindAsync(courseCode);
    if (existingCourse == null)
    {
      return new ResponseDTO(false, "Course Not found");
    }

    await this._dbContext.SaveChangesAsync();
    return new ResponseDTO(true, "Course Deleted Successfully");
  }
}
