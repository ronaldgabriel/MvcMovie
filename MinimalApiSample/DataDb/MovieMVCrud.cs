using Microsoft.EntityFrameworkCore;
using MinimalApiSample.Models;

namespace MinimalApiSample.DataDb
{
    public class MovieMVCrud : DbContext
    {
        public MovieMVCrud(DbContextOptions<MovieMVCrud> options) 
            : base(options)
        {
        }
        public DbSet<MovieModel> Movie { get; set; }

    }
}
