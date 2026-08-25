using Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityMapping;

public class ExperienceMapping : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder
            .ToTable("Experience")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.RolName)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(x => x.CompanyName)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasData(
            new Experience { 
                Id = 1, 
                RolName = "Stagiair", 
                CompanyName = "iCapps", 
                StartDate = new DateTime(2021, 4, 19, 0, 0, 0, DateTimeKind.Utc), 
                EndDate = new DateTime(2021, 6, 13, 0, 0, 0, DateTimeKind.Utc), 
                WebsiteUrl = "https://www.icapps.com/"
            },
            new Experience {
                Id = 2, 
                RolName = "Fullstack developer", 
                CompanyName = "Taglayer", 
                StartDate = new DateTime(2021, 10, 4, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2025, 10, 18, 0, 0, 0, DateTimeKind.Utc), 
                WebsiteUrl = "https://taglayer.com/"
            }
        );

        builder
            .HasMany(x => x.Skills)
            .WithMany(x => x.Experiences)
            .UsingEntity(
                "ExperienceSkill",
                j => j.HasData(
                    new { SkillsId = 1, ExperiencesId = 2 },
                    new { SkillsId = 2, ExperiencesId = 1 },
                    new { SkillsId = 3, ExperiencesId = 1 },
                    new { SkillsId = 3, ExperiencesId = 2 },
                    new { SkillsId = 4, ExperiencesId = 2 },
                    new { SkillsId = 6, ExperiencesId = 2 },
                    new { SkillsId = 7, ExperiencesId = 2 }
                )
            );
    }
}
