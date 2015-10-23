using System.Web.Mvc;

/*
Нужен для выдачи базовой информации о сервере
*/

namespace API.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
  }
}