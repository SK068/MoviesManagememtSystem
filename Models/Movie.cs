using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagememtSystem.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string plot { get; set; }
        public int publishTime { get; set; }
        public bool IsHit { get; set; }
        public DateTime ProduceDt { get; set; }
    }
}
