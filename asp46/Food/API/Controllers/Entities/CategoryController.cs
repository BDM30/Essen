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
  public class CategoryController : ApiController
  {
    private ICommonRepository<Category> categoryRepository;

    public CategoryController(ICommonRepository<Category> categories)
    {
      categoryRepository = categories;
    }

    [Route("Category/all")]
    [HttpGet]
    public IEnumerable<Category> GetCategories()
    {
      return categoryRepository.Data;
    }

    [HttpGet]
    [Route("Category/getby")]
    public IEnumerable<Category> GetCategoryBy([FromUri] Category c)
    {
      return (from x in categoryRepository.Data
              where (x.CategoryID == c.CategoryID && x.CategoryID != 0 ||
              x.Name == c.Name && x.Name != null)
              select x);
    }

    // если id валидный - то редактирование, иначе создастся новый
    [HttpGet]
    [Route("Category/save")]
    public string SaveCategory([FromUri] Category c)
    {
      categoryRepository.SaveData(c);
      return "ok";
    }

    [HttpGet]
    [Route("Category/remove")]
    public string RemoveCategory(int id)
    {
      categoryRepository.DeleteData(id);
      return "ok";
    }

  }
}
