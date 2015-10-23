using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Domain.Abstract;
using Domain.Entities;

/*
Котроллер сущности позволяет совершать CRUD операции и в будущем и другие
*/

namespace API.Controllers.Entities
{
  public class UserProductController : ApiController
  {
    private ICommonRepository<UserProduct> userProductRepository;

    public UserProductController(ICommonRepository<UserProduct> userProducts)
    {
      userProductRepository = userProducts;
    }

    [Route("UserProduct/all")]
    [HttpGet]
    public IEnumerable<UserProduct> GetUserProducts()
    {
      return userProductRepository.Data;
    }

    [HttpGet]
    [Route("UserProduct/getby")]
    public IEnumerable<UserProduct> GetUserProductBy([FromUri] UserProduct p)
    {
      return (from x in userProductRepository.Data
              where (x.UserID == p.UserID && x.UserID != 0 || x.Amount == p.Amount && x.Amount != 0
                     || x.CategoryID == p.CategoryID && x.CategoryID != 0 || 
                     x.ExpirationDate == p.ExpirationDate && x.ExpirationDate != null ||
                     x.ProductID == p.ProductID && x.ProductID != 0 ||
                     x.UserProductID == p.UserProductID && x.UserProductID != 0) 
              select x);
    }

    // если id валидный - то редактирование, иначе создастся новый
    [HttpGet]
    [Route("UserProduct/save")]
    public string SaveUserProduct([FromUri] UserProduct up)
    {
      userProductRepository.SaveData(up);
      return "ok";
    }

    [HttpGet]
    [Route("UserProduct/remove")]
    public string RemoveUserProduct(int id)
    {
      userProductRepository.DeleteData(id);
      return "ok";
    }
  }
}