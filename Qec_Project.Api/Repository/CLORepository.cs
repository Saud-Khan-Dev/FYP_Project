using Microsoft.EntityFrameworkCore;
using QEC_Project.API.DTOs;
using Qec_Project.Api.model;
using QEC_Project.API.Common;

namespace QEC_Project.API.Repository
{


  public class CLORepository : ICLORepository
  {

    private DBContext _dBContext;

    public CLORepository(DBContext dBContext)
    {
      this._dBContext = dBContext;
    }

    public async Task<ResponseDTO> CreateCLO(CLODTO createClo)
    {
      try
      {
        var course = await _dBContext
             .Course
             .Include(c => c.CLO)
             .FirstOrDefaultAsync(c => c.Id == createClo.CourseId);
        if (course == null)
        {
          return new ResponseDTO(false, "Course is Not Found");
        }
        var clo = new CLOModel()
        {
          CLOName = createClo.CLOName,
          Description = createClo.Description,
          UnitNumber = createClo.UnitNumber,
          CourseId = createClo.CourseId
        };
        course.CLO.Add(clo);
        await this._dBContext.CLO.AddAsync(clo);
        await this._dBContext.SaveChangesAsync();

        return new ResponseDTO(true, "Syllabus Created Successfully");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }

    }

    public async Task<Result<List<CLODTO>>> GetCLO(int courseId)
    {
      try
      {
        var res = await this._dBContext.CLO.Where(clo => clo.CourseId == courseId).Select(cl => new CLODTO()
        {
          Id = cl.Id,
          CLOName = cl.CLOName,
          Description = cl.Description,
          UnitNumber = cl.UnitNumber,
          CourseId = cl.CourseId
        }).ToListAsync();

        return Result<List<CLODTO>>.OK(res);
      }
      catch (Exception e)
      {
        return Result<List<CLODTO>>.Failure(e.Message);
      }
    }


    public async Task<ResponseDTO> UpdateCLO(CLODTO updateClo)
    {

      try
      {
        var clo = await this._dBContext.CLO.FindAsync(updateClo.Id);
        if (clo == null)
        {
          return new ResponseDTO(false, "CLO not found");
        }
        clo.CLOName = updateClo.CLOName; clo.Description = updateClo.Description; clo.UnitNumber = updateClo.UnitNumber;
        this._dBContext.CLO.Update(clo);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "CLO updated successfully");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);
      }

    }

    public async Task<ResponseDTO> DeleteCLO(string id)
    {
      try
      {
        var clo = await this._dBContext.CLO.FindAsync(id);
        if (clo == null)
        {
          return new ResponseDTO(false, "CLO not found");
        }
        this._dBContext.Remove(clo);
        await this._dBContext.SaveChangesAsync();
        return new ResponseDTO(true, "CLO deleted successfully");
      }
      catch (Exception e)
      {
        return new ResponseDTO(false, e.Message);

      }
    }
  }
}