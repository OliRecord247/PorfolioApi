using Data;

namespace Api.Endpoints.Skills;

public static class GetSkillById
{
    public static void MapGetById(this WebApplication app)
    {
        app.MapGet("/skills/{id}", async (int id, PortfolioDBContext context) =>
        {
            var skill = await context.Skills.FindAsync(id);
            if (skill is null) Results.NotFound();

            return Results.Ok(skill);
        });
    }
}
