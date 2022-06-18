using Project.DAL.Interfaces;
using Project.DAL.Interfaces.Repositories;
using Project.DAL.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenreRepository _genreRepository { get; }
        public IMovieGenreRepository _movieGenreRepository { get; }
        public IMovieRepository _movieRepository { get; }
        public ISeanceRepository _seanceRepository { get; }

        private readonly IDbTransaction _dbTransaction;

        public UnitOfWork(IGenreRepository genreRepository,
                          IMovieGenreRepository movieGenreRepository,
                          IMovieRepository movieRepository,
                          ISeanceRepository seanceRepository,
                          IDbTransaction dbTransaction)
        {
            _genreRepository = genreRepository;
            _movieGenreRepository = movieGenreRepository;
            _movieRepository = movieRepository;
            _seanceRepository = seanceRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
            }
        }

        public void Dispose()
        {
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }


    }
}
