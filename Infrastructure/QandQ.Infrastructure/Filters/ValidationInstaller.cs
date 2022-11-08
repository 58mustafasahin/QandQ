using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace QandQ.Infrastructure.Filters
{
    public static class ValidationInstaller
    {
        public static void AddFluentValidator(this IServiceCollection services)
        {
            //Fluent validation settings
            var assembler = AppDomain.CurrentDomain.Load("QandQ.Application");
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(assembler));

            //[ApiController] tag prevent default BadRequest return
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }
    }
}
