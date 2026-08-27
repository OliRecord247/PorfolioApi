using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Portfolio;

public class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public SkillLevel Level { get; set; }
    public string Image { get; set; }
    public List<string> Tags { get; set; } = [];
    public List<Experience> Experiences { get; set; }
    public List<Course> Courses { get; set; }
}
