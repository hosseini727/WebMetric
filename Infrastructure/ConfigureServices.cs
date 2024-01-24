using Application.Common.Behaviours;
using Application.Interface;
using Application.Metric.CalculateMetrics;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CalculateMetricsHandler).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddSingleton<IMetricService, MetricService>();
            services.AddSingleton<IRecommendationService, RecommendationService>();
            return services;
        }
    }

}
