using ManagerModel.Models;
using Microsoft.EntityFrameworkCore;
using MinimalApiSample.DbMysql;
using MinimalApiSample.IIterfaces;
using MinimalApiSample.ModelsMysql;

namespace MinimalApiSample.ServiceCustom
{
    public class DataServiceMysql : IDataServiceMsql
    {
        private readonly DataBaseMsql _context;
        public DataServiceMysql(DataBaseMsql context)
        {
            _context = context;

        }

        public async Task<List<UserMysql>> GetDataAsync()
        {
            return await _context.UserMysqls.ToListAsync();
        }
        public async Task<UserMysql> DeleteDataIdAsync(string Id)
        {
            var DataId = Guid.Parse(Id);
            var element = await _context.UserMysqls.Where(x => x.Id.Equals(DataId)).FirstAsync();
            if (element == null)
            {
                return new UserMysql() { Id = DataId, Name = "Element Not Found ", LastName = "null" };
            }
            _context.UserMysqls.Remove(element);
            await _context.SaveChangesAsync();
            return element;
        }
        public async Task<UserMysql> GetDataIdAsync(string Id)
        {
            var DataId = Guid.Parse(Id);
            return await _context.UserMysqls.Where(x => x.Id.Equals(DataId)).FirstAsync();
        }

        public async Task<UserMysql> PostItemAsync(UserMysql item)
        {

            item.Id = Guid.NewGuid();
           

            await _context.UserMysqls.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserMysql> PutItemAsync(UserMysql item)
        {

            var Item = await _context.UserMysqls.FindAsync(item.Id);

            Item.Name = item.Name == null ? "Data Null" : item.Name;
            Item.LastName = item.LastName;

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
