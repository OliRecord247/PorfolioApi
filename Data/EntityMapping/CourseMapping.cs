using Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityMapping;

public class CourseMapping : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
           .ToTable("Course")
           .HasKey(x => x.Id);

        builder
            .Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.Institution)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(300);

        builder
            .HasData(
                new Course { 
                    Id = 1,
                    Title = "Toegepaset Informatica, applicatieontwikkeling",
                    Category = CourseCategory.Academic,
                    Institution = "Karel de Grote",
                    StartDate = new DateTime(2017, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 9, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Course
                {
                    Id = 2,
                    Title = "Fullstack developer",
                    Category = CourseCategory.Training,
                    Institution = "VDAB",
                    StartDate = new DateTime(2017, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 9, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

        builder
            .HasMany(x => x.Skills)
            .WithMany(x => x.Courses)
            .UsingEntity(
                "CourseSkill",
                j => j.HasData(
                    new { CoursesId = 2, SkillsId = 5 },
                    new { CoursesId = 2, SkillsId = 9 }
                )
            );
    }
}
