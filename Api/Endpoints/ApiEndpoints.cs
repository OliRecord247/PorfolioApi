using Api.Endpoints.Skills;

namespace Api.Endpoints;

public static class ApiEndpoints
{
    public static void MapApiEndpoints(this WebApplication app)
    {
        app.UseSkillEndpoints();
    }
}
