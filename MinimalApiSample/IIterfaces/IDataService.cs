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
    public interface IDataServiceMysql
    {
        Task<List<UserMysql>> GetDataAsync();
        Task<UserMysql> GetDataIdAsync(Guid Id);
        Task<UserMysql> DeleteDataIdAsync(Guid Id);
        Task<UserMysql> PostItemAsync(UserMysql item);
        Task<UserMysql> PutItemAsync(UserMysql item);

    }
    public interface IDataServiceTestMsql
    {
        List<UserMysql> GetDataAsync();
        //UserMysql GetDataIdAsync(string Id);
        //UserMysql DeleteDataIdAsync(string Id);
        //UserMysql PostItemAsync(UserMysql item);
        //UserMysql PutItemAsync(UserMysql item);

    }
}
