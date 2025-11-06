using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class XrefFacultyCoursesConfiguration : IEntityTypeConfiguration<XrefFacultyCourses>
{
  public void Configure(EntityTypeBuilder<XrefFacultyCourses> entityTypeBuilder)
  {
    entityTypeBuilder.HasKey(t => new { t.FacultyId, t.CourseId });
    entityTypeBuilder.HasOne(cf => cf.CourseModel)
      .WithMany(f => f.XrefFacultyCourses)
      .HasForeignKey(fk => fk.CourseId);

    entityTypeBuilder.HasOne(faculty => faculty.FacultyModel)
      .WithMany(faculty => faculty.XrefFacultyCourses)
      .HasForeignKey(fk => fk.FacultyId);
  }
}