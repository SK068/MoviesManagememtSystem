using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagememtSystem.Models
{
    public class Maker
    {
        public int ID { get; set; }//Primary key
        [Required]
        public string Name { get; set; }//Name of producer
        [Required]
        public string Gender { get; set; }//gender of producer
        public DateTime DOB { get; set; }//DOB of producer
        public string Bio { get; set; }//Bio of producer
        public int MovieFK { get; set; }
        [ForeignKey("MovieFK")]//Foreign key used
        public Movie Movie { get; set; }
    }
}
