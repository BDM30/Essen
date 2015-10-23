using System.Linq;
using Essen.Models;
using Essen.Models.Entities;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Essen.Controllers
{
    public class Test : Controller
    {
      private DataContext data;

      // берем из Startup.cs
      public Test(DataContext input)
      {
        data = input;
      }

      public string One()
      {
        User user = new User() {Name = "Vlad"};
        data.Add(user);
        data.SaveChanges();
        return data.Users.Count().ToString();
      }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
