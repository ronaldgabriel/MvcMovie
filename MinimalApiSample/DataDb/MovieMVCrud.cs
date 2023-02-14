
using ManagerModel.Models;
using Microsoft.EntityFrameworkCore;


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
