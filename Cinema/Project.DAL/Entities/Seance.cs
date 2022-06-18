using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Seance
    {
        public int id { get; set; }
        public int cinema_id { get; set; }
        public int movie_id { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
    }
}
