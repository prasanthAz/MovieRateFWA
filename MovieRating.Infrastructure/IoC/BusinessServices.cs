using Microsoft.Extensions.DependencyInjection;
using MovieRating.Business;
using MovieRating.Business.Interfaces;

namespace MovieRating.Infrastructure.IoC
{
    public static class BusinessServices
    {

        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
