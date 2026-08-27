using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Portfolio;

public class Course
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Institution { get; set; }
    public CourseCategory Category { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
    public List<Skill> Skills { get; set; }
}
