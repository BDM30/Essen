using Xunit;
using Essen.Controllers;
using Essen.Models.Entities;

// Facts are tests which are always true. They test invariant conditions.
// Theories are tests which are only true for a particular set of data.

// https://xunit.github.io/docs/getting-started-dnx.html1

namespace Tests.CrudControllers
{
  public class UserTests
  {
    [Fact]
    public void can_get_data()
    {
      // Arrange - create a controller with a mock repository
      UserController target = new UserController(new UserRepositoryMock());

      // Action
      User[] result = target.Get().ToArray();

      // Assert
      Assert.AreEqual(result.Length, 3);
      Assert.AreEqual(1, result[0].UserID);
      Assert.AreEqual(2, result[1].UserID);
      Assert.AreEqual(3, result[2].UserID);
    }

    //[Fact]
    //public void can_get_data_one()
    //{
    //  // Arrange - create a controller with a mock repository
    //  UserController target = new UserController(new UserRepositoryMock());

    //  // Action
    //  User result1 = target.Get(1); // true
    //  User result2 = target.Get(144); // false

    //  // Assert
    //  Assert.AreEqual(null, result2);
    //  Assert.AreEqual("Vlad", result1.Name);
    //}

  }
}