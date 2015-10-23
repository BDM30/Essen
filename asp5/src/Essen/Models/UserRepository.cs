using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essen.Models.Entities;

namespace Essen.Models
{
    public class UserRepository : IRepository<User>
    {
      private DataContext context;

      public UserRepository(DataContext c)
      {
        context = c;
      }

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
        context.Users.Update(data);
      }
      context.SaveChanges();
    }

    public void DeleteData(int userId)
    {
      User user = (from x in context.Users
                   where x.UserID == userId
                   select x).FirstOrDefault();
      if (user != null)
      {
        context.Users.Remove(user);
        context.SaveChanges();
      }
    }
  }
}
