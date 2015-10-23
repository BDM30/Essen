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
  public class ProductController : ApiController
  {
    private ICommonRepository<Product> productRepository;

    public ProductController(ICommonRepository<Product> products)
    {
      productRepository = products;
    }

    [Route("Product/all")]
    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
      return productRepository.Data;
    }

    [HttpGet]
    [Route("Product/getby")]
    public IEnumerable<Product> GetProductBy([FromUri] Product p)
    {
      return (from x in productRepository.Data
              where (x.AmountDefault == p.AmountDefault && x.AmountDefault != 0 ||
              x.CategoryID == p.CategoryID && x.CategoryID != 0 ||
              x.UnitMeasureID == p.UnitMeasureID && x.UnitMeasureID != 0 ||
              x.Name == p.Name && x.Name != null ||
              x.ProductID == p.ProductID && x.ProductID != 0)
              select x);
    }

    // если id валидный - то редактирование, иначе создастся новый
    [HttpGet]
    [Route("Product/save")]
    public string SaveProduct([FromUri] Product r)
    {
      productRepository.SaveData(r);
      return "ok";
    }

    [HttpGet]
    [Route("Product/remove")]
    public string RemoveProduct(int id)
    {
      productRepository.DeleteData(id);
      return "ok";
    }
  }
}
