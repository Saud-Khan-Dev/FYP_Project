using Microsoft.EntityFrameworkCore;
using QEC_Project.API.Common;
using Qec_Project.Api.model;

namespace QEC_Project.API.Repository
{
  public class TeachingWeeklyScheduleRepository : ITeachingWeeklyScheduleRepository
  {
    private DBContext _dBContext;
    public TeachingWeeklyScheduleRepository(DBContext dBContext)
    {
      this._dBContext = dBContext;
    }



    public async Task<ResponseDTO> CreateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto)
    {

      try
      {
        var course = await this._dBContext.Course.Include(c => c.TeachingWeeklySchedules).FirstOrDefaultAsync(c => c.Id == teachingWeeklyScheduleDto.CourseId);
        if (course == null)
        {
          return new ResponseDTO(false, "No course is Found");
        }

        var schedule = new TeachingWeeklySchedule()
        {
          WeekName = teachingWeeklyScheduleDto.WeekName,
          WeeklyContent = teachingWeeklyScheduleDto.WeeklyContent,
          CourseId = teachingWeeklyScheduleDto.CourseId
        };
        course.TeachingWeeklySchedules.Add(schedule);

        await this._dBContext.TeachingWeeklySchedules.AddAsync(schedule);
        await this._dBContext.SaveChangesAsync();

        return new ResponseDTO(true, "Syllabus is created for this course");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }

    }

    public async Task<Result<TeachingWeeklyScheduleDTO>> GetSchedule(string id)
    {
      try
      {
        var res = await this._dBContext.TeachingWeeklySchedules.FindAsync(id);
        if (res == null)
        {
          return Result<TeachingWeeklyScheduleDTO>.Failure("No Schedule");
        }
        var schedule = new TeachingWeeklyScheduleDTO()
        {
          Id = res.Id,
          WeekName = res.WeekName,
          WeeklyContent = res.WeeklyContent,
          CourseId = res.CourseId,
        };
        return Result<TeachingWeeklyScheduleDTO>.OK(schedule);


      }
      catch (Exception e)
      {

        return Result<TeachingWeeklyScheduleDTO>.Failure(e.Message);


      }
    }

    public async Task<ResponseDTO> UpdateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto)
    {
      try
      {
        var res = await this._dBContext.TeachingWeeklySchedules.FindAsync(teachingWeeklyScheduleDto.Id);
        if (res == null)
        {
          return new ResponseDTO(false, "Schedule is not found");
        }

        res.CourseId = teachingWeeklyScheduleDto.CourseId;
        res.WeekName = teachingWeeklyScheduleDto.WeekName;
        res.WeeklyContent = teachingWeeklyScheduleDto.WeeklyContent;

        this._dBContext.TeachingWeeklySchedules.Update(res);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "Schedule is Updated successfully");


      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }
    }
    public async Task<ResponseDTO> DeleteSchedule(string id)
    {
      try
      {
        var res = await this._dBContext.TeachingWeeklySchedules.FindAsync(id);
        if (res == null)
        {
          return new ResponseDTO(false, "Schedule is not found");

        }

        this._dBContext.TeachingWeeklySchedules.Remove(res);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "Schedule is deleted successfully");


      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }
    }
  }
}