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

    public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SkillMapping());
    }
}
