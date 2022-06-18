using Project.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Interfaces.Repositories.Base
{
    public interface IUnitOfWork
    {
        IGenreRepository _genreRepository { get; }
        IMovieRepository _movieRepository { get; }
        IMovieGenreRepository _movieGenreRepository { get; }
        ISeanceRepository _seanceRepository { get; }
        void Commit();
        void Dispose();

    }
}
