using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса FoodContext
*/

namespace Domain.Concrete
{
  public class CategoryRepository : ICommonRepository<Category>
  {
    private FoodContext context = new FoodContext();

    public IEnumerable<Category> Data
    {
      get { return context.Categories; }
    }

    public void SaveData(Category data)
    {
      if (data.CategoryID == 0)
      {
        context.Categories.Add(data);
      }
      else
      {
        Category dbEntry = context.Categories.Find(data.CategoryID);
        if (dbEntry != null)
        {
          dbEntry.Name = data.Name;
        }
      }
      context.SaveChanges();
    }

    public Category DeleteData(int categoryId)
    {
      Category dbEntry = context.Categories.Find(categoryId);
      if (dbEntry != null)
      {
        context.Categories.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
