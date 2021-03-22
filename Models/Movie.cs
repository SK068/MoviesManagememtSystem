using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagememtSystem.Models
{
    public class Movie
    {
        public int ID { get; set; }//Primary key
        public string MovieName { get; set; }//Name of movie
        [Required]
        [StringLength(50)]
        public string plot { get; set; }//plot of movie
        public int publishTime { get; set; }//publish date of movie
        public bool IsHit { get; set; }//bool is used
        public DateTime ProduceDt { get; set; }//produce date of movie
    }
}
