using Azure;
using ManagerModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace _MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        List<MovieModel> movies = new List<MovieModel>();
        //private  JsonSerializerOptions _options; 
        static HttpClient client = new HttpClient();
        private readonly IHttpClientFactory httpClientFactory;
        public MoviesController(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        // Infomacion tipo List
        public async Task<IActionResult> Index()
        {


            
                 
              



            var httpClient = httpClientFactory.CreateClient("APIDirection");
            // client.BaseAddress = new Uri("https://localhost:7075/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

            var respose = await  httpClient.GetAsync("https://localhost:7075/todoitems").ConfigureAwait(false);
            if (respose.IsSuccessStatusCode)
            {
                var apiResponse = await respose.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<MovieModel>>(apiResponse);
            }
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync("https://localhost:7075/todoitems"))
            //    {
            //        if (response.IsSuccessStatusCode) 
            //        {
            //            var apiResponse = await response.Content.ReadAsStringAsync();
            //            movies = JsonConvert.DeserializeObject<List<MovieModel>>(apiResponse);
            //        }
                    
            //    }
            //}
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieModel model)
        {

            try
            {
                MovieModel obj = new MovieModel();
                model.ReleaseDate = DateTime.Now;
                model.Id = Guid.NewGuid();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:7075/TodoPost", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<MovieModel>(apiResponse);
                    }
                }
            }catch(Exception ex) { }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateReservation(MovieModel _model)
        {
            MovieModel model = new MovieModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7075/ChangeData" +_model.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<MovieModel>(apiResponse);
                }
            }
            return View(model);
        }
    }
}
