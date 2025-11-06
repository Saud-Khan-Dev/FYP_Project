using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{

  public DBContext(DbContextOptions<DBContext> options) : base(options){}

  public DbSet<AdminModel> Admin { get; set; }
  public DbSet<FacultyModel> Faculty { get; set; }
  public DbSet<CourseModel> Course { get; set; }
  public DbSet<CLOModel> CLO { get; set; }
  public DbSet<XrefFacultyCourses> XrefFacultyCourses { get; set; }
  public DbSet<SyllabusModel> SyllabusModel { get; set; }
  public DbSet<RecommendedReadings> RecommendedReadings { get; set; }
  public DbSet<TeachingWeeklySchedule> TeachingWeeklySchedules { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new AdminConfiguration());
    modelBuilder.ApplyConfiguration(new FacultyConfiguration());
    modelBuilder.ApplyConfiguration(new XrefFacultyCoursesConfiguration());
    modelBuilder.ApplyConfiguration(new CourseConfiguration());
    modelBuilder.ApplyConfiguration(new CLOConfiguration());
    modelBuilder.ApplyConfiguration(new SyllabusConfiguration());
    modelBuilder.ApplyConfiguration(new RecommendedReadingsConfiguration());
    modelBuilder.ApplyConfiguration(new TeachingWeeklyScheduleConfiguration());
  }
}