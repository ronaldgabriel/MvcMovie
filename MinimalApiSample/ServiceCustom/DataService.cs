using ManagerModel.Models;
using Microsoft.EntityFrameworkCore;
using MinimalApiSample.DataDb;
using MinimalApiSample.IIterfaces;

namespace MinimalApiSample.ServiceCustom
{
    public class DataService : IDataService
    {
        private readonly MovieMVCrud _context;
        public DataService(MovieMVCrud context)
        {
            _context = context;

        }

        public Task<List<MovieModel>> GetDataAsync()
        {
            return _context.Movie.ToListAsync();
        }

        public async Task<MovieModel> GetDataIdAsync(string Id)
        {
            var DataId = Guid.Parse(Id);
            return await _context.Movie.Where( x => x.Id.Equals(DataId)).FirstAsync();
        }
        public async Task<MovieModel> DeleteDataIdAsync(string Id)
        {
            var DataId = Guid.Parse(Id);
            var element = await _context.Movie.Where(x => x.Id.Equals(DataId)).FirstAsync();
            if (element == null)
            {
                return new MovieModel() { Id = DataId, Title = "Element Not Found " ,Genre = "null"};
            }
            _context.Movie.Remove(element);
            await _context.SaveChangesAsync();
            return element;
        }

        public  async Task<MovieModel> PostItemAsync(MovieModel item)
        {
            var Item = new MovieModel
            {
                Id= Guid.NewGuid(),
                Title = item.Title,
                Genre = item.Genre,
            };

            await _context.Movie.AddAsync(Item);
            await _context.SaveChangesAsync();


            return item;
        }

        public  async Task<MovieModel> PutItemAsync(MovieModel item)
        {
            var Item =  await _context.Movie.FindAsync(item.Id);

            Item.Title = item.Title == null ? "Data Null" : item.Title;
            Item.Genre = item.Genre;

            await _context.SaveChangesAsync();

            return item;

        }
    }
}
