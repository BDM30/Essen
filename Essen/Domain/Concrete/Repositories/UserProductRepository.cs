/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса DataContext
*/

using System.Collections.Generic;
using Essen.Domain.Abstract;
using Essen.Domain.Entities;

namespace Essen.Domain.Concrete.Repositories
{
  public class UserProductRepository : ICommonRepository<UserProduct>
  {
    private DataContext context = new DataContext();

    public IEnumerable<UserProduct> Data
    {
      get { return context.UserProducts; }
    }

    public void SaveData(UserProduct data)
    {
      if (data.UserProductID == 0)
      {
        context.UserProducts.Add(data);
      }
      else
      {
        UserProduct dbEntry = context.UserProducts.Find(data.UserProductID);
        if (dbEntry != null)
        {
          dbEntry.Amount = data.Amount;
          dbEntry.CategoryID = data.CategoryID;
          dbEntry.ExpirationDate = data.ExpirationDate;
          dbEntry.ProductID = data.ProductID;
          dbEntry.UserID = data.UserID;
        }
      }
      context.SaveChanges();
    }

    public UserProduct DeleteData(int userProductId)
    {
      UserProduct dbEntry = context.UserProducts.Find(userProductId);
      if (dbEntry != null)
      {
        context.UserProducts.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
