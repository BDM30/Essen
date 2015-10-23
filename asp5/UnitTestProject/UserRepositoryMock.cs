using System.Collections.Generic;
using System.Linq;
using Essen.Models.Entities;
using Essen.Models;

namespace UnitTestProject
{
  public class UserRepositoryMock : IRepository<User>
  {
    public List<User> users;

    public UserRepositoryMock()
    {
      users = new List<User>();
      users.Add(new User() { UserID = 1, Name = "Vlad", Password = "Kool" });
      users.Add(new User() { UserID = 2, Name = "Vlads", Password = "Kooler" });
      users.Add(new User() { UserID = 3, Name = "Vlade", Password = "Koolx" });

    }

    public IEnumerable<User> Data
    {
      get { return (IEnumerable<User>)users; }
    }

    public void SaveData(User data)
    {
      if (data.UserID == 0)
      {
        users.Add(data);
      }
      else
      {
        foreach (var usr in (IEnumerable<User>)users)
        {
          if (usr.UserID == data.UserID)
          {
            usr.Name = data.Name;
            usr.Password = data.Password;
            return;
          }
        }

      }
    }

    public void DeleteData(int id)
    {
      User user = (from x in (IEnumerable<User>)users
                   where id == x.UserID
                   select x).FirstOrDefault();
      if (user != null)
      {
        users.Remove(user);
      }
    }
  }
}