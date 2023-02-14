using ManagerModel.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApiSample.ModelsMysql;

namespace MinimalApiSample.IIterfaces
{
    public interface IDataService
    {
        Task<List<MovieModel>> GetDataAsync();
        Task<MovieModel> GetDataIdAsync(string Id);
        Task<MovieModel> DeleteDataIdAsync(string Id);
        Task<MovieModel> PostItemAsync(MovieModel item);
        Task<MovieModel> PutItemAsync(MovieModel item);

    }
    public interface IDataServiceMsql
    {
        Task<List<UserMysql>> GetDataAsync();
        Task<UserMysql> GetDataIdAsync(string Id);
        Task<UserMysql> DeleteDataIdAsync(string Id);
        Task<UserMysql> PostItemAsync(UserMysql item);
        Task<UserMysql> PutItemAsync(UserMysql item);

    }
}
