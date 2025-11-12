using Qec_Project.Api.model;

namespace QEC_Project.API.Repository
{
  public interface ISyllabusRepository
  {
    public Task<ResponseDTO> CreateSyllabus(SyllabusDTO createSyllabusDto);
    public Task<List<SyllabusDTO>> GetSyllabus();
    public Task<ResponseDTO> UpdateSyllabus(SyllabusDTO syllabusModel);
    public Task<ResponseDTO> DeleteSyllabus(string id);
    
  }

}