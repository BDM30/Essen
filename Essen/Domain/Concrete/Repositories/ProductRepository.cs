/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса DataContext
*/

using System.Collections.Generic;
using Essen.Domain.Abstract;
using Essen.Domain.Entities;

namespace Essen.Domain.Concrete.Repositories
{
  public class ProductRepository : ICommonRepository<Product>
  {
    private DataContext context = new DataContext();

    public IEnumerable<Product> Data
    {
      get { return context.Products; }
    }

    public void SaveData(Product data)
    {
      if (data.ProductID == 0)
      {
        context.Products.Add(data);
      }
      else
      {
        Product dbEntry = context.Products.Find(data.ProductID);
        if (dbEntry != null)
        {
          dbEntry.Name = data.Name;
          dbEntry.AmountDefault = data.AmountDefault;
          dbEntry.CategoryID = data.CategoryID;
          dbEntry.UnitMeasureID = data.UnitMeasureID;
        }
      }
      context.SaveChanges();
    }

    public Product DeleteData(int productId)
    {
      Product dbEntry = context.Products.Find(productId);
      if (dbEntry != null)
      {
        context.Products.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
