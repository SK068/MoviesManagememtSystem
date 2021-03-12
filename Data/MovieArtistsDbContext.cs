using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MoviesManagememtSystem.Models;

namespace MoviesManagememtSystem.Data
{
    public class MovieArtistsDbContext : DbContext
    {
        // Here we add in all the tables we are using.
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieArtist> MovieArtist { get; set; }
        public DbSet<Maker> Maker { get; set; }
        // We need 2 constructors, one is empty, and the other injects in DbContextOptions
        public MovieArtistsDbContext(DbContextOptions<MovieArtistsDbContext> options)
        : base(options)
        {
        }
        public MovieArtistsDbContext()
        {
        }
       
    }
}
