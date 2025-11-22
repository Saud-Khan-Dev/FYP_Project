using Qec_Project.Api.model;
using QEC_Project.API.Common;

namespace QEC_Project.API.Repository
{
  public interface ITeachingWeeklyScheduleRepository
  {
    public Task<ResponseDTO> CreateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto);
    public Task<Result<TeachingWeeklyScheduleDTO>> GetSchedule(string id);
    public Task<ResponseDTO> UpdateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto);
    public Task<ResponseDTO> DeleteSchedule(string id);


  }
}