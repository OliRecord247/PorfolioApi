using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Endpoints.Vaardigheden;

public static class GetAllSkills
{
    public static void MapGetAll(this WebApplication app)
    {
        app.MapGet("/skills", async (PortfolioDBContext context) =>
        {
            var skills = await context.Skills.ToListAsync();
            return Results.Ok(skills);
        });
    }
}
