using System.Web.Http.Cors;
using System.Web.Mvc;

namespace MovieWebService.Controllers
{
     [EnableCors(origins: "http://cinerchweb.azurewebsites.net", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
