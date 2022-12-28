using Microsoft.EntityFrameworkCore;
using MinimalApiSample.Models;

namespace MinimalApiSample.DataDb
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

        public DbSet<AllItems> Todos => Set<AllItems>();
    }
}
