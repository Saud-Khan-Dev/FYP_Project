public class CourseDTO
{
    public string? CourseCode { get; set; }
    public string? Description { get; set; }
    public int? TheoreyCreditHours { get; set; }
    public int? LabCreditHours { get; set; }
    public bool? IsActive { get; set; }

    public CourseDTO(string? courseCode, string? description, int? theoreyCreditHours, int? labCreditHours, bool? isActive)
    {
        CourseCode = courseCode;
        Description = description;
        TheoreyCreditHours = theoreyCreditHours;
        LabCreditHours = labCreditHours;
        IsActive = isActive;
    }
}
