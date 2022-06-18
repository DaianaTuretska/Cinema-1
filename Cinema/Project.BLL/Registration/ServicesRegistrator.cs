using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.BLL.Interfaces.Services;
using Project.BLL.Services;

namespace BLL.Registration
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<ISeanceService, SeanceService>()
            .AddTransient<IGenreService, GenreService>()
            .AddTransient<IMovieService, MovieService>()
            .AddTransient<IMovieGenreService, MovieGenreService>()

       ;
    }
}
