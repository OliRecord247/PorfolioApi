using Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

        builder.HasData(
            new Skill { Id = 1, Name = "Vue", Level = SkillLevel.Advanced },
            new Skill { Id = 2, Name = "React", Level = SkillLevel.Beginner }
        );
    }
}
