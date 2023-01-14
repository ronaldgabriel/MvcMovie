using ManagerModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerModel.DATAs
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
