using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Portfolio;

public class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public SkillLevel Level { get; set; }
    public required string Image { get; set; }
    public List<string> Tags { get; set; } = [];
}
