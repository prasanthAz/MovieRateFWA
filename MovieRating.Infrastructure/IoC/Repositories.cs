using Microsoft.Extensions.DependencyInjection;
using MovieRating.Repository;
using MovieRating.Repository.Interfaces;

namespace MovieRating.Infrastructure.IoC
{
    public static class Repositories
    {
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
