using Microsoft.EntityFrameworkCore;
using Qec_Project.Api.model;

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
      var course = await this._dBContext.Course.FindAsync(createSyllabusDto.CourseId);
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

    public async Task<List<SyllabusDTO>> GetSyllabus()
    {
      var res = await this._dBContext.SyllabusModel.ToListAsync();
      var syllabus = res.Select(c => new SyllabusDTO()
      {
        Id = c.Id,
        TypicalContentOfSyllbus = c.TypicalContentOfSyllbus,
        RecommendedReadingsId = c.RecommendedReadingsId,
        CourseId = c.CourseId
      }).ToList();

      return syllabus;
    }

    public async Task<ResponseDTO> UpdateSyllabus(SyllabusDTO syllabusDto)
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

    public async Task<ResponseDTO> DeleteSyllabus(string id)
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
  }
}