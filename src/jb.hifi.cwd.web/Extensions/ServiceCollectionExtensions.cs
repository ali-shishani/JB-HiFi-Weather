using AspNetCoreRateLimit;
using jb.hifi.web.Config;

namespace jb.hifi.cwd.web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        //{
        //    // Used to store rate limit counters and ip rules
        //    services.AddMemoryCache();

        //    // Load in general configuration and ip rules from appsettings.json
        //    var limitSettingsSection = configuration.GetSection("IpRateLimitingSettings");
        //    services.Configure<IpRateLimitOptions>(options => limitSettingsSection.Bind(options));

        //    var limitPoliciesSection = configuration.GetSection("IpRateLimitingPolicies");
        //    services.Configure<IpRateLimitPolicies>(options => limitPoliciesSection.Bind(options));

        //    // Inject Counter and Store Rules
        //    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        //    services.AddSingleton<IRateLimitConfiguration, CustomRateLimitConfiguration>();
        //    services.AddInMemoryRateLimiting();

        //    // Return the services
        //    return services;
        //}
    }
}
