using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса FoodContext
*/

namespace Domain.Concrete
{
  public class RecipeRepository : ICommonRepository<Recipe>
  {
    private FoodContext context = new FoodContext();

    public IEnumerable<Recipe> Data
    {
      get { return context.Recipes; }
    }

    public void SaveData(Recipe data)
    {
      if (data.RecipeID == 0)
      {
        context.Recipes.Add(data);
      }
      else
      {
        Recipe dbEntry = context.Recipes.Find(data.RecipeID);
        if (dbEntry != null)
        {
          dbEntry.Name = data.Name;
          dbEntry.ProcessDescription = data.ProcessDescription;
        }
      }
      context.SaveChanges();
    }

    public Recipe DeleteData(int recipeId)
    {
      Recipe dbEntry = context.Recipes.Find(recipeId);
      if (dbEntry != null)
      {
        context.Recipes.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
