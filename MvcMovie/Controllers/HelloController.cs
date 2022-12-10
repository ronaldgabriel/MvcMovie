using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Xml.Linq;

namespace MvcMovie.Controllers
{
    public class HelloController : Controller
    {
        // GET: /HelloWorld/
        public string Index(string name = "Ronald", int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");

        }
       
        public ActionResult Welcome()
        {
            return View();

        }
        public ActionResult MoveList()
        {

            return View();

        }
    }
}
