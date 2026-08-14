using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Portfolio;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SkillLevel Level { get; set; }
}
