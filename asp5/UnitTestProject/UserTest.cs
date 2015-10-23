using System.Collections.Generic;
using System.Linq;
using Xunit;
using Essen.Controllers;
using Essen.Models.Entities;

namespace UnitTestProject
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
  public class UserTest
  {

    [Fact]
    public void can_get_data()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());

      // Action
      IEnumerable<User> users = target.Get();
      User[] result = users.ToArray();

      // Assert
      Assert.Equal(result.Length, 3);
      Assert.Equal(1, result[0].UserID);
      Assert.Equal(2, result[1].UserID);
      Assert.Equal(3, result[2].UserID);
    }

    [Fact]
    public void can_get_data_one()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());

      // Action
      User result1 = target.Get(1); // true
      User result2 = target.Get(144); // false

      // Assert
      Assert.Equal(null, result2);
      Assert.Equal("Vlad", result1.Name);
    }

    [Fact]
    public void can_save_user()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());
      // Arrange - new user
      User user = new User() {Name = "Nameff", Password = "PassME"};

      // Action
      target.Post(user);
      IEnumerable<User> users = target.Get();
      User[] result = users.ToArray();

      //
      Assert.Equal(result.Length, 4);
      Assert.Equal(1, result[0].UserID);
      Assert.Equal(2, result[1].UserID);
      Assert.Equal(3, result[2].UserID);
      Assert.Equal("Nameff", result[3].Name);
    }

    [Fact]
    public void can_update_user()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());
      // Arrange - new user
      User user = new User() { Name = "Nameff", Password = "PassME" };
      // Action
      target.Put(1, user);
      IEnumerable<User> users = target.Get();
      User[] result = users.ToArray();

      //
      Assert.Equal(result.Length, 3);
      Assert.Equal("Nameff", result[0].Name);
      Assert.Equal(2, result[1].UserID);
      Assert.Equal(3, result[2].UserID);
    }

    [Fact]
    public void can_remove_user()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());

      // Arrange - new user
      User user = new User() { Name = "Nameff", Password = "PassME" };
      target.Delete(1);

      // Assert
      IEnumerable<User> users = target.Get();
      User[] result = users.ToArray();
      Assert.Equal(result.Length, 2);
      Assert.Equal(2, result[0].UserID);
      Assert.Equal(3, result[1].UserID);
    }

  }

}
