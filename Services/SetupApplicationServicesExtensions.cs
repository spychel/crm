using Microsoft.Extensions.DependencyInjection;
using Services.Services.LessonsService;
using Services.Services.StudentsService;

namespace Services;

public static class SetupApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
        services
        .AddScoped<StudentsService>()
        .AddScoped<LessonsService>();
}