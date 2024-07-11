using Domain.Entities;
using Domain.Primitieves.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Dal.Configurations;

/// <summary>
/// Класс конфигурации преподавателя
/// </summary>
public class EducatorConfiguration : IEntityTypeConfiguration<Educator>
{
    /// <summary>
    /// Метод конфигурации
    /// </summary>
    public void Configure(EntityTypeBuilder<Educator> builder)
    {
        builder.HasKey(p => p.Id);
         
        builder.Property(p => p.Id)
            .HasColumnName("id");
         
        builder.OwnsOne(p => p.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
 
            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasColumnName("surname");
 
            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasColumnName("patronymic");
        });
 
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.None)
            .HasColumnName("gender");
 
        builder.Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnName("birth_date")
            .HasColumnType("timestamp without time zone");
 
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasColumnName("phone");
    }
}