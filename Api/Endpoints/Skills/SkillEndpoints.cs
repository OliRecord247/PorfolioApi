using Api.Endpoints.Vaardigheden;

namespace Api.Endpoints.Skills;

public static class SkillEndpoints
{
    public static void UseSkillEndpoints(this WebApplication app)
    {
        app.MapGetAll();
        app.MapGetById();
    }
}
