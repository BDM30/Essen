using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса FoodContext
*/

namespace Domain.Concrete
{
  public class IngredientRepository : ICommonRepository<Ingredient>
  {
    private FoodContext context = new FoodContext();

    public IEnumerable<Ingredient> Data
    {
      get { return context.Ingredients; }
    }

    public void SaveData(Ingredient data)
    {
      if (data.IngredientID == 0)
      {
        context.Ingredients.Add(data);
      }
      else
      {
        Ingredient dbEntry = context.Ingredients.Find(data.IngredientID);
        if (dbEntry != null)
        {
          dbEntry.CategoryID = data.CategoryID;
          dbEntry.Amount = data.Amount;
          dbEntry.ImportanceLevel = data.ImportanceLevel;
          dbEntry.RecipeID = data.RecipeID;
          dbEntry.ReplaceabilityLevel = data.ReplaceabilityLevel;
        }
      }
      context.SaveChanges();
    }

    public Ingredient DeleteData(int ingredientId)
    {
      Ingredient dbEntry = context.Ingredients.Find(ingredientId);
      if (dbEntry != null)
      {
        context.Ingredients.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
