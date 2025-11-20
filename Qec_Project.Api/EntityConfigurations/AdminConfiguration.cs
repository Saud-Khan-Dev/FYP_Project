using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AdminConfiguration : IEntityTypeConfiguration<AdminModel>
{

  public void Configure(EntityTypeBuilder<AdminModel> entityBuilder)
  {

    entityBuilder.HasKey(t => t.Id);
    entityBuilder.Property(t => t.Name)
              .HasMaxLength(100).IsRequired(true)
              .HasMaxLength(100);
    entityBuilder.Property(t => t.Email)
              .HasMaxLength(200).IsRequired();
    entityBuilder.Property(t => t.PhoneNumber)
              .HasMaxLength(50).IsRequired();
    entityBuilder.Property(t => t.Password)
              .HasMaxLength(255).IsRequired();
    entityBuilder.Property(t => t.Role)
              .HasMaxLength(20).IsRequired();
    entityBuilder.Property(t => t.Gender)
              .HasMaxLength(90).IsRequired();
    entityBuilder.Property(t => t.DateOfJoining)
              .IsRequired();

  }


}