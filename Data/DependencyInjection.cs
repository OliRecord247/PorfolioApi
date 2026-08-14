using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<PortfolioDBContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=portfolioDB;Username=fiesta_admin;Password=fiesta_admin_password");
        });

        return services;
    }
}
