using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RecommendedReadingsConfiguration:IEntityTypeConfiguration<RecommendedReadings>
{
  public void Configure(EntityTypeBuilder<RecommendedReadings> entityTypeBuilder)
  {
  entityTypeBuilder.HasKey(t => t.Id);
  entityTypeBuilder.Property(p => p.Reading).IsRequired();
  }
}