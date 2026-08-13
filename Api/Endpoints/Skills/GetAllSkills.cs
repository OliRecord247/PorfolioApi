namespace Api.Endpoints.Vaardigheden;

public static class GetAllSkills
{
    public static void MapGetAll(this WebApplication app)
    {
        app.MapGet("/skills", () =>
        {
            return Results.Ok(new[] { "Node", "Vue", "OOP" });
        });
    }
}
