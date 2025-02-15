
using Microsoft.Extensions.DependencyInjection;

namespace Representation
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddRepresentation(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            
            return services;
        }
    }
}