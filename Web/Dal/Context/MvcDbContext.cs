using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Web.Dal.Configurations;

namespace Web.Dal.Context;

/// <summary>
/// Контекст базы данных
/// </summary>
public class MvcDbContext : DbContext
{
    public DbSet<Student> Students { get; init; }
    public DbSet<Course> Courses { get; init; }
    public DbSet<Educator> Educators { get; init; }

    public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options)
    {
    }
    
    public MvcDbContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql(
            "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=postgres");
    }
    
    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new EducatorConfiguration());
    }
}