using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApiSample.IIterfaces;
using MinimalApiSample.ModelsMysql;

namespace MinimalApiSample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMysqlController : ControllerBase
    {
        private readonly IDataServiceMysql _service;

        public UserMysqlController(IDataServiceMysql service)
        {
            // _MyConsultApi = MyConsultApi;
            _service = service;

        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetTodoItems()
        {
            var data = await _service.GetDataAsync();
            return Ok(data);
        }

        [HttpPost, Authorize]
        [Route("AddNewElement")]
        public async Task<IActionResult> PostItem(UserMysql item)
        {
            // can evaluate item if null etc 
            //  return await _service.PostItemAsync(item);
            await _service.PostItemAsync(item);
            return Ok(item);
        }
        [HttpGet, Authorize]
        [Route("GetId")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var element = await _service.GetDataIdAsync(Id);
            return Ok(element);
        }
        [HttpDelete, Authorize]
        [Route("DeleteElement")]
        public async Task<IActionResult> DeleteByIdAsync(Guid Id)
        {
            var element = await _service.DeleteDataIdAsync(Id);



            if (element != null)
            {
                if (element.LastName == "null")
                {
                    return NotFound(element);
                }
                else
                {
                    return Ok(element);

                }
            }
            else
            {
                return Ok(element);
            }

        }
        
        [HttpPut, Authorize]
        [Route("UpdateElement")]
        public async Task<IActionResult> PutItem(UserMysql item)
        {
            // can evaluate item if null etc 
            // return
            await _service.PutItemAsync(item);
            return Ok(item);
        }

    }
}
