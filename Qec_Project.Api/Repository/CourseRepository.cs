using Microsoft.EntityFrameworkCore;
using Qec_Project.Api.model;
using QEC_Project.API.Common;

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
    try
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
    catch (Exception e)
    {
      return new ResponseDTO(false, e.Message);

    }
  }

  public async Task<Result<List<CourseModel>>> GetAllCourse()
  {
    try
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
      return Result<List<CourseModel>>.OK(response);
    }
    catch (Exception e)
    {
      return Result<List<CourseModel>>.Failure(e.Message);

    }
  }

  public async Task<Result<CourseDTO>> GetSpecificCourse(string courseCode)
  {
    try
    {
      var course = this._dbContext.Course.FirstOrDefault(cc => cc.CourseCode == courseCode);
      if (course == null)
      {
        return Result<CourseDTO>.Failure("Not Found");
      }

      var cour = new CourseDTO(course.CourseCode, course.Description, course.TheoreyCreditHours, course.LabCreditHours, course.IsActive);

      return Result<CourseDTO>.OK(cour);
    }
    catch (Exception e)
    {
      return Result<CourseDTO>.Failure(e.Message);

    }
  }

  public async Task<ResponseDTO> UpdateCourse(CourseModel courseModel)
  {
    try
    {
      var existingCourse = await this.GetSpecificCourse(courseModel.CourseCode);
      if (!existingCourse.Success)
      {
        return new ResponseDTO(false, "Course Not found");
      }

      existingCourse.Value.CourseCode = courseModel.CourseCode;
      existingCourse.Value.Description = courseModel.Description;
      existingCourse.Value.TheoreyCreditHours = courseModel.TheoreyCreditHours;
      existingCourse.Value.LabCreditHours = courseModel.LabCreditHours;
      existingCourse.Value.IsActive = courseModel.IsActive;
      await this._dbContext.SaveChangesAsync();
      return new ResponseDTO(true, "Course updated successfully");
    }
    catch (Exception e)
    {
      return new ResponseDTO(false, e.Message);
    }
  }

  public async Task<ResponseDTO> DeleteCourse(string courseCode)
  {
    try
    {
      var existingCourse = await this._dbContext.Course.FindAsync(courseCode);
      if (existingCourse == null)
      {
        return new ResponseDTO(false, "Course Not found");
      }

      await this._dbContext.SaveChangesAsync();
      return new ResponseDTO(true, "Course Deleted Successfully");
    }
    catch (Exception e)
    {
      return new ResponseDTO(false, e.Message);
    }
  }
}
