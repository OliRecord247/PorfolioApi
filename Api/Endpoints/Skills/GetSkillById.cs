namespace Api.Endpoints.Skills;

public static class GetSkillById
{
    public static void MapGetById(this WebApplication app)
    {
        app.MapGet("/skills/{id}", (int id) =>
        {
            return Results.Ok(new { id, name = "Oliver", fname = "Verdesseldonck" });
        });
    }
}
