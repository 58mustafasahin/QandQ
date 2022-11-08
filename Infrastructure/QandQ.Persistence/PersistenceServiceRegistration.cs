using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QandQ.Application.Repositories.Movies;
using QandQ.Application.Repositories.RateAndNoteMovies;
using QandQ.Application.Repositories.Roles;
using QandQ.Application.Repositories.UserRoles;
using QandQ.Application.Repositories.Users;
using QandQ.Persistence.Contexts;
using QandQ.Persistence.Repositories.Movies;
using QandQ.Persistence.Repositories.RateAndNoteMovies;
using QandQ.Persistence.Repositories.Roles;
using QandQ.Persistence.Repositories.UserRoles;
using QandQ.Persistence.Repositories.Users;

namespace QandQ.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<QandQDbContext>(options => options.UseInMemoryDatabase(configuration.GetConnectionString("InMemoryDb")));

            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
            services.AddScoped<IRateAndNoteMovieReadRepository, RateAndNoteMovieReadRepository>();
            services.AddScoped<IRateAndNoteMovieWriteRepository, RateAndNoteMovieWriteRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<IUserRoleReadRepository, UserRoleReadRepository>();
            services.AddScoped<IUserRoleWriteRepository, UserRoleWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            return services;
        }
    }
}
