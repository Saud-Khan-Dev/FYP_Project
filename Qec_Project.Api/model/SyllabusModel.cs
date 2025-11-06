public class SyllabusModel
{
  public int Id { get; set; }
  public IList<string> TypicalContentOfSyllbus { get; set; }
  public int CourseId { get; set; }
  public CourseModel CourseModel { get; set; }
  public int RecommendedReadingsId { get; set; }
  public IList<RecommendedReadings> RecommendedReadings { get; set; }

}