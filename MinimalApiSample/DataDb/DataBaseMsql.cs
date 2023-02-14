

using Microsoft.EntityFrameworkCore;
using MinimalApiSample.ModelsMysql;

namespace MinimalApiSample.DbMysql
{
    public  class DataBaseMsql : DbContext
    {
       

        public DataBaseMsql(DbContextOptions<DataBaseMsql> options)
                : base(options)
        {
        }
        public DbSet<UserMysql> UserMysqls { get; set; }
    }
}
