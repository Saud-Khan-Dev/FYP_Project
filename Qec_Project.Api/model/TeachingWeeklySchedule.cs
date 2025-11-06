public class TeachingWeeklySchedule
{
  public int Id { get; set; }
  public string WeekName { get; set; }
  public string WeeklyContent { get; set; }
  public int CourseId { get; set; }
  public CourseModel CourseModel { get; set; }
}