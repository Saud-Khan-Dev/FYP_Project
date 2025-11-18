
public class CLOModel
{
  public int Id { get; set; }
  public string CLOName { get; set; }
  public string Description { get; set; }
  public string UnitNumber { get; set; }
  public int CourseId { get; set; }
  public CourseModel Course { get; set; }

}