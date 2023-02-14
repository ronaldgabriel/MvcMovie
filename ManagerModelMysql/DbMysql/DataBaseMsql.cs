

using ManagerModelMysql.ModelsMysql;
using Microsoft.EntityFrameworkCore;

namespace ManagerModelMysql.DbMysql
{
    public  class DataBaseMsql : DbContext
    {
        public DbSet<UserMysql> UserMysqls { get; set; }

        public DataBaseMsql(DbContextOptions<DataBaseMsql> options)
                : base(options)
        {
        }
    }
}
