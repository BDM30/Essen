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
  public class RecipeController : ApiController
  {
    private ICommonRepository<Recipe> recipeRepository;

    public RecipeController(ICommonRepository<Recipe> recipes)
    {
      recipeRepository = recipes;
    }

    [Route("Recipe/all")]
    [HttpGet]
    public IEnumerable<Recipe> GetRecipes()
    {
      return recipeRepository.Data;
    }

    [HttpGet]
    [Route("Recipe/getby")]
    public IEnumerable<Recipe> GetRecipeBy([FromUri] Recipe r)
    {
      return (from x in recipeRepository.Data
              where (x.Name == r.Name && x.Name != null || x.ProcessDescription == r.ProcessDescription && x.ProcessDescription != null
              || x.RecipeID == r.RecipeID && x.RecipeID != 0)
              select x);
    }

    // если id валидный - то редактирование, иначе создастся новый
    [HttpGet]
    [Route("Recipe/save")]
    public string SaveRecipe([FromUri] Recipe r)
    {
      recipeRepository.SaveData(r);
      return "ok";
    }

    [HttpGet]
    [Route("Recipe/remove")]
    public string RemoveRecipe(int id)
    {
      recipeRepository.DeleteData(id);
      return "ok";
    }
  }
}
