using Microsoft.EntityFrameworkCore;
using Qec_Project.Api.model;
using QEC_Project.API.Common;

namespace QEC_Project.API.Repository
{
  public class SyllabusRepository : ISyllabusRepository
  {

    private DBContext _dBContext;
    public SyllabusRepository(DBContext dBContext)
    {
      this._dBContext = dBContext;
    }
    public async Task<ResponseDTO> CreateSyllabus(SyllabusDTO createSyllabusDto)
    {
      try
      {
        var course = await this._dBContext.Course.FirstOrDefaultAsync(cs => cs.Id == createSyllabusDto.CourseId);
        if (course == null)
        {
          return new ResponseDTO(false, "No course is Found");
        }
        var syllabus = new SyllabusModel()
        {
          TypicalContentOfSyllbus = createSyllabusDto.TypicalContentOfSyllbus,
          CourseId = createSyllabusDto.CourseId
        };
        course.SyllabusId = createSyllabusDto.Id;
        this._dBContext.Course.Update(course);
        await this._dBContext.SyllabusModel.AddAsync(syllabus);
        await this._dBContext.SaveChangesAsync();
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "Syllabus Created Successfully");
      }
      catch (Exception e)
      {

        return new ResponseDTO(false, e.Message);

      }
    }

    public async Task<Result<List<SyllabusDTO>>> GetSyllabus(int courseId)
    {
      try
      {
        var res = this._dBContext.SyllabusModel.Where(cs => cs.CourseId == courseId);
        var syllabus = res.Select(c => new SyllabusDTO()
        {
          Id = c.Id,
          TypicalContentOfSyllbus = c.TypicalContentOfSyllbus,
          RecommendedReadingsId = c.RecommendedReadingsId,
          CourseId = c.CourseId
        }).ToList();

        return Result<List<SyllabusDTO>>.OK(syllabus);
      }
      catch (Exception e)
      {
        return Result<List<SyllabusDTO>>.Failure(e.Message);

      }
    }

    public async Task<ResponseDTO> UpdateSyllabus(SyllabusDTO syllabusDto)
    {
      try
      {
        var syllabus = await this._dBContext.SyllabusModel.FindAsync(syllabusDto.Id);
        if (syllabus == null)
        {
          return new ResponseDTO(false, "Syllabus is not found");
        }
        syllabus.CourseId = syllabusDto.CourseId;
        syllabus.TypicalContentOfSyllbus = syllabusDto.TypicalContentOfSyllbus;
        syllabus.RecommendedReadingsId = syllabusDto.RecommendedReadingsId;

        this._dBContext.SyllabusModel.Update(syllabus);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "Syllabus is Updated successfully");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }
    }

    public async Task<ResponseDTO> DeleteSyllabus(string id)
    {
      try
      {
        var syllabus = await this._dBContext.SyllabusModel.FindAsync(id);
        if (syllabus == null)
        {
          return new ResponseDTO(false, "Syllabus is not found");
        }
        this._dBContext.SyllabusModel.Remove(syllabus);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "Syllabus is Deleted successfully");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }
    }
  }
}