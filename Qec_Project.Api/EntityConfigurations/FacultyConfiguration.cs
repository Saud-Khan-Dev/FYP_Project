using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FacultyConfiguration : IEntityTypeConfiguration<FacultyModel>
{
  public void Configure(EntityTypeBuilder<FacultyModel> entityBuilber)
  {
    entityBuilber.HasKey(t => t.Id);
    entityBuilber.Property(t => t.Name)
              .HasMaxLength(100).IsRequired(true)
              .HasMaxLength(100);
    entityBuilber.Property(t => t.Email)
              .HasMaxLength(200).IsRequired();
    entityBuilber.Property(t => t.PhoneNumber)
              .HasMaxLength(50).IsRequired();
    entityBuilber.Property(t => t.PasswordHash)
              .HasMaxLength(255).IsRequired();
    entityBuilber.Property(t => t.Role)
              .HasMaxLength(20).IsRequired();
    entityBuilber.Property(t => t.Gender)
              .HasMaxLength(90).IsRequired();
    entityBuilber.Property(t => t.EmployeeId)
              .IsRequired()
              .HasMaxLength(80);
    entityBuilber.Property(t => t.Department)
              .IsRequired()
              .HasMaxLength(100);
    entityBuilber.Property(t => t.Designation)
              .IsRequired()
              .HasMaxLength(100);
    entityBuilber.Property(t => t.DateOfJoining)
      .IsRequired();
  }
}