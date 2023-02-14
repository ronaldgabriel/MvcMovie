using ManagerModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ServiceOdata.Controllers
{
    public class OdataServicePointController : ODataController
    {
        private List<OdataModel> _OdataModel = new List<OdataModel>()
        {
            new OdataModel()
            {
                ID = 1,
                Name = "Bread",
            }
        };

        [EnableQuery]
        public ActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
