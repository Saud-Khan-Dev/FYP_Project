using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseConfiguration : IEntityTypeConfiguration<CourseModel>
{
  public void Configure(EntityTypeBuilder<CourseModel> entityTypeBuilder)
  {
    entityTypeBuilder.HasKey(c => c.Id);

    entityTypeBuilder.Property(c => c.CourseCode)
           .IsRequired()
           .HasMaxLength(50);

    entityTypeBuilder.Property(c => c.Description)
           .HasMaxLength(500);

    entityTypeBuilder.Property(c => c.TheoreyCreditHours)
           .IsRequired();

    entityTypeBuilder.Property(c => c.LabCreditHours)
           .IsRequired();

    entityTypeBuilder.Property(c => c.IsActive)
           .HasDefaultValue(true);

    entityTypeBuilder.Property(c => c.CreatedAt)
           .IsRequired();
    entityTypeBuilder.HasMany(c => c.CLO)
              .WithOne(c => c.Course)
              .HasForeignKey(fk => fk.CourseId)
              .OnDelete(DeleteBehavior.Cascade);

    entityTypeBuilder.HasOne(s => s.SyllabusModel)
                .WithOne(c => c.CourseModel)
                .HasForeignKey<SyllabusModel>(fk => fk.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

    entityTypeBuilder.HasMany(c => c.TeachingWeeklySchedules)
      .WithOne(t => t.CourseModel)
      .HasForeignKey(fk => fk.CourseId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}