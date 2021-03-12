using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagememtSystem.Models
{
    public class MovieArtist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string gender { get; set; }
        public DateTime DOB { get; set; }
        public string Bio { get; set; }
        public bool IsFamous { get; set; }
        public int MovieFK { get; set; }
        [ForeignKey("MovieFK")]
        public Movie Movie { get; set; }
    }
}
