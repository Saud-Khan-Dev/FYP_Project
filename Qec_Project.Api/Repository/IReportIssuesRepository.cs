using Microsoft.AspNetCore.Mvc;
using Qec_Project.Shared.Models;

public interface IReportIssuesRepository
{
  public List<Dictionary<string,string>> GetCourses();
  public List<Dictionary<int, string>> GetInstructor();
  public List<Dictionary<int, string>> GetSemesters();
  public OkObjectResult SubmitReport(CreateIssueModel createIssueDTO);


}