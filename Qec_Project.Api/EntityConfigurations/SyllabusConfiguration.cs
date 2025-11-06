using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SyllabusConfiguration:IEntityTypeConfiguration<SyllabusModel>
{
  public void Configure(EntityTypeBuilder<SyllabusModel> entityTypeBuilder)
  {
       entityTypeBuilder.HasKey(t => t.Id);
              entityTypeBuilder.HasMany(s => s.RecommendedReadings)
                          .WithOne(r => r.SyllabusModel)
                          .HasForeignKey(fk => fk.SyllabusId)
                          .OnDelete(DeleteBehavior.Cascade);
  }
}