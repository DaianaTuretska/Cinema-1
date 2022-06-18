using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Cinema
    {
        public int id { get; set; }
        public string name_cinema { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public bool is_active { get; set; }

    }
}
