using System.Collections.Generic;
using System.Web.Http;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;

/*
Котроллер сущности позволяет совершать CRUD операции и в будущем и другие
*/

/*
Todo: сделать более рациональную Route System
*/

namespace API.Controllers
{
    public class UserController : ApiController
    {

      private ICommonRepository<User> userRepository;

      public UserController(ICommonRepository<User> users)
      {
        userRepository = users;
      }

    [Route("User/all")]
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
      return userRepository.Data;
    }

      [HttpGet]
      [Route("User/getby")]
      public IEnumerable<User> GetUserBy([FromUri] User user)
      {
      // Сработает если идет совпадение хотябы по 1 не пустому параметру
      return (from x in userRepository.Data
               where (x.UserID == user.UserID && x.UserID != 0 || x.Name == user.Name && x.Name != null
               || x.Password == user.Password && x.Password != null)
               select x);
      }
      
      // если id валидный - то редактирование, иначе создастся новый
      [HttpGet]
      [Route("User/save")]
      public string SaveUser([FromUri] User user)
      {
        userRepository.SaveData(user);
        return "ok";
      }

    [HttpGet]
    [Route("User/remove")]
    public string RemoveUser(int id)
    {
      userRepository.DeleteData(id);
      return "ok";
    }

  }
}
