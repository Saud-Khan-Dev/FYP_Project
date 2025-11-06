using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TeachingWeeklyScheduleConfiguration:IEntityTypeConfiguration<TeachingWeeklySchedule>
{
  public void Configure(EntityTypeBuilder<TeachingWeeklySchedule> entityTypeBuilder)
  {
    entityTypeBuilder.HasKey(t => t.Id);
  entityTypeBuilder.Property(p => p.WeekName).IsRequired();
  }
}