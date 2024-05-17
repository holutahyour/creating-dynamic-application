using Application.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProgramApplicationRepository, ProgramApplicationRepository>();
            services.AddScoped<ICandidateInformationRepository, CandidateInformationRepository>();

            services.AddScoped<IProgramApplicationService, ProgramApplicationService>();
            services.AddScoped<ICandidateInformationService, CandidateInformationService>();

            return services;
        }
    }
}