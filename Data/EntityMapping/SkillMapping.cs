using Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Data.EntityMapping;

public class SkillMapping : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder
            .ToTable("Skills")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(x => x.Level)
            .IsRequired();

        builder
            .Property(x => x.Tags)
            .HasConversion(
                v => JsonSerializer.Serialize(v),
                v => JsonSerializer.Deserialize<List<string>>(v) ?? new List<string>()
            )
            .HasColumnType("jsonb")
            .Metadata
            .SetValueComparer(new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                ));

        builder.HasData(
            new Skill { Id = 1, Name = "Vue", Image = "vue.svg", Level = SkillLevel.Advanced, Tags = ["frontend", "SPA"] },
            new Skill { Id = 2, Name = "React", Image = "react.svg", Level = SkillLevel.Beginner, Tags = ["fronted", "SPA"] },
            new Skill { Id = 3, Name = "TypeScript", Image = "typescript.svg", Level = SkillLevel.Advanced, Tags = ["fullstack", "api"] },
            new Skill { Id = 4, Name = "Tailwind", Image = "tailwind.svg", Level = SkillLevel.Intermediat, Tags = ["fronted"] },
            new Skill { Id = 5, Name = ".NET", Image = "dotnet.svg", Level = SkillLevel.Beginner, Tags = ["fullstack", "api"] },
            new Skill { Id = 6, Name = "Docker", Image = "docker.svg", Level = SkillLevel.Intermediat, Tags = ["backend"] },
            new Skill { Id = 7, Name = "MongoDB", Image = "mongodb.svg", Level = SkillLevel.Advanced, Tags = ["backend", "database"] },
            new Skill { Id = 8, Name = "PostgreSQL", Image = "postgresql.svg", Level = SkillLevel.Intermediat, Tags = ["backend", "database"] },
            new Skill { Id = 9, Name = "Blazor", Image = "blazor.svg", Level = SkillLevel.Beginner, Tags = ["frontend", "SPA"] },
            new Skill { Id = 10, Name = "REST API", Image = "rest.svg", Level = SkillLevel.Advanced, Tags = ["backend"] },
            new Skill { Id = 11, Name = "Node", Image = "node.svg", Level = SkillLevel.Advanced, Tags = ["backend"] }
        );
    }
}
