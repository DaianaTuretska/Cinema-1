using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CinemaPlan
    {
        public int id { get; set; }
        public int cinema_id { get; set; }
        public int row_number { get; set; }
        public int place_number { get; set; }

    }
}
