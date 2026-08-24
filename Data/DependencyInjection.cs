using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionStr)
    {
        services.AddDbContext<PortfolioDBContext>(contextOptions =>
        {
            contextOptions.UseNpgsql(connectionStr, options => {
                options.MaxBatchSize(150);
            });
        });

        return services;
    }
}
