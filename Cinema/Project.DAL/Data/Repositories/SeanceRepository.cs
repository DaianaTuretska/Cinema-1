using Project.DAL.Data.Repositories.Base;
using Project.DAL.Entities;
using Project.DAL.Interfaces.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Data.Repositories
{
    public class SeanceRepository : GenericRepository<Seance>, ISeanceRepository
    {
        public SeanceRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Seance")
        {
        }

        public async Task<IEnumerable<Seance>> GetSeanceByMoveiIdSPADOASync(int id)
        {
            using (SqlConnection sql = new SqlConnection(_sqlConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSeancesByMovieIdSP", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@movie_id", id));
                    var response = new List<Seance>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }
        private Seance MapToValue(SqlDataReader reader)
        {
            return new Seance()
            {
                id = (int)reader["id"],
                cinema_id = (int)reader["cinema_id"],
                movie_id = (int)reader["movie_id"],
                date = (DateOnly)reader["date"],
                time = (TimeOnly)reader["time"],
            };
        }


    }
}
