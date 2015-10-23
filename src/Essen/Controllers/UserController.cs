using System.Collections.Generic;
using System.Linq;
using Essen.Models;
using Essen.Models.Entities;
using Microsoft.AspNet.Mvc;

/*
Пример CRUD контроллера с 4мя сущностями
*/

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

// guide to use postman


/*

*/

namespace Essen.Controllers
{
  [Route("api/[controller]")]
  public class UserController : Controller
  {
    private IRepository<User> data;

    public UserController(IRepository<User> d)
    {
      data = d;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<User> Get()
    {
      return data.Data;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public User Get(int id)
    {
      return (from x in data.Data
              where x.UserID == id
              select x).FirstOrDefault();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] User user)
    {
      data.SaveData(user);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User user)
    {
      user.UserID = id;
      data.SaveData(user);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      data.DeleteData(id);
    }

  }
}
