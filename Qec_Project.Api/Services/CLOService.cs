using QEC_Project.API.Common;
using QEC_Project.API.DTOs;
using Qec_Project.Api.model;
using QEC_Project.API.Repository;

namespace QEC_Project.API.Services
{
  public class CLOService
  {
    private CLORepository _repo;

    public CLOService(CLORepository repo)
    {
      this._repo = repo;
    }

    public async Task<ResponseDTO> CreateClo(CLODTO clo)
    {
      return await this._repo.CreateCLO(clo);

    }

    public async Task<Result<List<CLODTO>>> GetClo(string courseId)
    {

      return await this._repo.GetCLO(int.Parse(courseId)); 

    }

    public async Task<ResponseDTO> UpdateClo(CLODTO clo)
    {
      return await this._repo.UpdateCLO(clo);
    }

    public async Task<ResponseDTO> DeleteClo(string id)
    {
      return await this._repo.DeleteCLO(id);
    }
  }
}
