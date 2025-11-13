using Microsoft.AspNetCore.Mvc;
using Qec_Project.Shared.Models;
namespace QEC_Project.API.controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReportIssues : ControllerBase
  {
    private readonly DBContext _dBContext;

    public ReportIssues(DBContext dBContext)
    {
      this._dBContext = dBContext;
    }


    [HttpGet("courses")]
    public List<Dictionary<int, string>> GetCourses()
    {

      List<Dictionary<int, string>> courses = new();

      courses.Add(new Dictionary<int, string>
      {
        {1, "Software Project Manager"},
        {2, "Software Re-Engineering"},
        {3, "Calculus"},

      });
      return courses;
    }

    [HttpGet("instructor")]
    public List<Dictionary<int, string>> GetInstructor()
    {

      List<Dictionary<int, string>> instructors = new();

      instructors.Add(new Dictionary<int, string>
      {
        {4, "Saud"},
        {5, "Ali"},
        {6, "Ahmad"},

      });
      return instructors;
    }

    [HttpGet("semester")]
    public List<Dictionary<int, string>> GetSemesters()
    {

      List<Dictionary<int, string>> semester = new();

      semester.Add(new Dictionary<int, string>
      {
        {7, "sem1"},
        {8, "sem2"},
        {9, "sem3"},

      });
      return semester;
    }


    [HttpPost("submit")]
    public OkObjectResult SubmitReport(CreateIssueModel createIssueDTO)
    {

      //Task Saving to DB
      var response = new Dictionary<string, string>()
      {
       { "message","Report is Submitted Successfully"}
      };

      return Ok(response);

    }

  }
}