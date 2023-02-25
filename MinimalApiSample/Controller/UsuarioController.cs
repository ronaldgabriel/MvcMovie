
using ManagerModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiSample.IIterfaces;

namespace MinimalApiSample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController  : ControllerBase
    {
        
        private readonly IDataService _service  ;
        // private readonly ILog _MyConsultApi;
        public UsuarioController(IDataService service)
        {
            // _MyConsultApi = MyConsultApi;
            _service = service;
               
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetTodoItems()
        {
            var data = await _service.GetDataAsync();
            return Ok(data);
        }
        [HttpGet, Authorize]
        [Route("Getid")]
        public async Task<IActionResult> GetStudentByIdAsync(string Id)
        {
            var element = await _service.GetDataIdAsync(Id);
            return Ok(element);
        }
        [HttpDelete, Authorize]
        [Route("DeleteElement")]
        public async Task<IActionResult> DeleteByIdAsync(string Id)
        {
            var element = await _service.DeleteDataIdAsync(Id);



            if (element != null)
            {
                if (element.Genre == "null")
                {
                    return NotFound(element);
                }
                else
                {
                    return Ok(element);

                }
            }
            else {
                return Ok(element);
            }
           
        }
        [HttpPost, Authorize]
        [Route("AddNewElement")]
        public async Task<ActionResult<MovieModel>> PostItem(MovieModel item)
        {
            // can evaluate item if null etc 
            return await _service.PostItemAsync(item);
        }
        [HttpPut, Authorize]
        [Route("UpdateElement")]
        public async Task<ActionResult<MovieModel>> PutItem(MovieModel item)
        {
            // can evaluate item if null etc 
            return await _service.PutItemAsync(item);

        }

    }
}
