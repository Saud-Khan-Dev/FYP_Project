using QEC_Project.API.Common;
using QEC_Project.API.DTOs;
using Qec_Project.Api.model;

namespace QEC_Project.API.Repository
{
  public interface ICLORepository
  {
    public Task<ResponseDTO> CreateCLO(CLODTO createClo);
    public Task<Result<List<CLODTO>>> GetCLO(int courseId);

    public Task<ResponseDTO> UpdateCLO(CLODTO updateClol);

    public Task<ResponseDTO> DeleteCLO(string id);
  }
}