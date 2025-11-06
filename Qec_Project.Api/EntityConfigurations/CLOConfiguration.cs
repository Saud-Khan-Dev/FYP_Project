using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CLOConfiguration:IEntityTypeConfiguration<CLOModel>
{
  public void Configure(EntityTypeBuilder<CLOModel> entityTypeBuilder)
  {
    entityTypeBuilder.HasKey(t => t.Id);
          entityTypeBuilder.Property(t => t.CLOName)
          .IsRequired()
          .HasMaxLength(100);
          entityTypeBuilder.Property(t => t.Description)
          .IsRequired()
          .HasMaxLength(2000);
          entityTypeBuilder.Property(t => t.UnitNumber)
          .IsRequired()
          .HasMaxLength(100);
  }
}