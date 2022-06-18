using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Customer
    {
        public int id_custom { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public string e_mail { get; set; }
        public string phone { get; set; }
        public string login { get; set; }
    }
}
