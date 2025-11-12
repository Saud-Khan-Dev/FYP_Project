public class SyllabusDTO
{
  public int Id { get; set; }
  public string TypicalContentOfSyllbus { get; set; }
  public int CourseId { get; set; }
  public CourseModel CourseModel { get; set; }
  public int RecommendedReadingsId { get; set; }
  public RecommendedReadings RecommendedReadings { get; set; }
}