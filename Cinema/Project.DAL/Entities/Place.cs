using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Place
    {
        public int id { get; set; }
        public int row { get; set; }
        public int place { get; set; }
        public string status { get; set; }
        public int cinema_id { get; set; }
        public int cost { get; set; }
    }
}
