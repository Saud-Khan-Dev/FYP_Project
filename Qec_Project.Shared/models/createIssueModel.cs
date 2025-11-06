namespace Qec_Project.Shared.Models
{
  public class CreateIssueModel
  {
    public List<Dictionary<int, string>> Subject { get; set; }
    public List<Dictionary<int, string>> Semester { get; set; }
    public List<Dictionary<int, string>> Instructor { get; set; }
    public string Problem { get; set; }
    public string ReportedBy { get; set; }
    public string SignatureImageUrl { get; set; }

  }
}