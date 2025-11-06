public class CourseModel
{
  public int Id { get; set; }
  public string CourseCode { get; set; }
  public string Description { get; set; }
  public int TheoreyCreditHours { get; set; }
  public int LabCreditHours { get; set; }
  public bool IsActive { get; set; } = true;
  public int SyllabusId { get; set; }
  public SyllabusModel SyllabusModel { get; set; }
  public IList<CLOModel> CLO { get; set; }
  public IList<TeachingWeeklySchedule> TeachingWeeklySchedules { get; set; }
  public IList<XrefFacultyCourses> XrefFacultyCourses { get; set; }
  public DateTime CreatedAt = DateTime.Now;
}


