using Qec_Project.Api.model;

namespace QEC_Project.API.Repository
{
  public interface ITeachingWeeklyScheduleRepository
  {
    public Task<ResponseDTO> CreateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto);
    public Task<TeachingWeeklyScheduleDTO> GetSchedule(string id);
    public Task<ResponseDTO> UpdateSchedule(TeachingWeeklyScheduleDTO teachingWeeklyScheduleDto);
    public Task<ResponseDTO> DeleteSchedule(string id);


  }
}