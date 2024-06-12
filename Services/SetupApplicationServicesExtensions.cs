using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class SetupApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
        .AddScoped<StudentService>();
}