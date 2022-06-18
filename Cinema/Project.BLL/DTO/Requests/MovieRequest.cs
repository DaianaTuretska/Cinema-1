using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Requests
{
    public class MovieRequest
    {
        public int id { get; set; }
        public string title { get; set; }
        public int age_bracket { get; set; }
        public string duraction { get; set; }
        public string description { get; set; }
        public DateOnly start_rental_date { get; set; }
        public DateOnly end_rental_time { get; set; }
    }
}
