namespace QEC_Project.API.Repository
{
  public class TeachingWeeklyScheduleDTO
  {
    public int Id { get; set; }

    public string WeekName { get; set; }
    public string WeeklyContent { get; set; }
    public int CourseId { get; set; }
  }
}