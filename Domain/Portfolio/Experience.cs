using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Portfolio;

public class Experience
{
    public int Id { get; set; }
    public string RolName { get; set; }
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string WebsiteUrl { get; set; }
    public List<Skill> Skills { get; set; }
}
