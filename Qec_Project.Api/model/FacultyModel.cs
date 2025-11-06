using System.ComponentModel.DataAnnotations;

public class FacultyModel : User
{

  public string EmployeeId { get; set; }

  public string Department { get; set; }

  public string Designation { get; set; }

   public IList<XrefFacultyCourses>XrefFacultyCourses  { get; set; }


}