using Microsoft.Extensions.DependencyInjection;
using QandQ.Infrastructure.Mailing;

namespace QandQ.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddScoped<IEmailService, EmailService>();
        }
    }
}
