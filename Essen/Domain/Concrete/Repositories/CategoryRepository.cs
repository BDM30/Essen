/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса DataContext
*/
using System.Collections.Generic;
using Essen.Domain.Abstract;
using Essen.Domain.Entities;

namespace Essen.Domain.Concrete.Repositories
{
  public class CategoryRepository : ICommonRepository<Category>
  {
    private DataContext context = new DataContext();

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
