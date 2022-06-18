using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Interfaces.Repositories.Base;

namespace Project.DAL.Interfaces.Repositories
{
    public interface IMovieGenreRepository : IGenericRepository<MovieGenre>
    {
    }
}
