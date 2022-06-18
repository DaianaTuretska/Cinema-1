using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Responses
{
    public class SeanceResponse
    {
        public int id { get; set; }
        public string name_cinema { get; set; }
        public string city { get; set; }
        public string title { get; set; }
        public string duraction { get; set; }
        public string description { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
    }
}
