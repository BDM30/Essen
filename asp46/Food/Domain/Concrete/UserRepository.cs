using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса FoodContext
*/

namespace Domain.Concrete
{
  public class UserRepository : ICommonRepository<User>
  {
    private FoodContext context = new FoodContext();

    public IEnumerable<User> Data
    {
      get { return context.Users; }
    }

    public void SaveData(User data)
    {
      if (data.UserID == 0)
      {
        context.Users.Add(data);
      }
      else
      {
        User dbEntry = context.Users.Find(data.UserID);
        if (dbEntry != null)
        {
          dbEntry.Name = data.Name;
          dbEntry.Password = data.Password;
        }
      }
      context.SaveChanges();
    }

    public User DeleteData(int userId)
    {
      User dbEntry = context.Users.Find(userId);
      if (dbEntry != null)
      {
        context.Users.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
