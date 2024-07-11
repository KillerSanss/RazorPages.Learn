using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Dal.Configurations;

/// <summary>
/// Класс конфигурации курса
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(p => p.Id);
         
        builder.Property(p => p.Id)
            .HasColumnName("id");
 
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnName("description");
        
        builder.Property(p => p.StartDate)
            .IsRequired()
            .HasColumnName("start_date")
            .HasColumnType("timestamp without time zone");
        
        builder.HasOne<Educator>()
            .WithMany(e => e.Courses)
            .HasForeignKey(c => c.EducatorId);
    }
}