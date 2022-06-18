using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Requests
{
    public class MovieGenreRequest
    {
        public int movie_id { get; set; }
        public int genre_id { get; set; }
    }
}
