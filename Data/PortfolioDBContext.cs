using Data.EntityMapping;
using Domain.Portfolio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data;

public class PortfolioDBContext : DbContext
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Experience> Experiences => Set<Experience>();

    public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SkillMapping());
        modelBuilder.ApplyConfiguration(new ExperienceMapping());
    }
}
