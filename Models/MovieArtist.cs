using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagememtSystem.Models
{
    public class MovieArtist
    {
        public int ID { get; set; }//Primary key
        [Required]
        public string Name { get; set; }//Name of Actor
        [Required]
        public string gender { get; set; }//Gender of Actor
        public DateTime DOB { get; set; }//DOB of actor
        public string Bio { get; set; }//Bio of actor
        public bool IsFamous { get; set; }
        public int MovieFK { get; set; }
        [ForeignKey("MovieFK")]//Foreign key used
        public Movie Movie { get; set; }
    }
}
