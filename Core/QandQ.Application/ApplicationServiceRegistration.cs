using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace QandQ.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ApplicationServiceRegistration));
            collection.AddHttpClient();
        }
    }
}
