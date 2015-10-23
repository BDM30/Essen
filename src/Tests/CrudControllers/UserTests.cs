using Xunit;
using Essen.Controllers;
using Tests.CrudControllers;
using Essen.Models.Entities;

// Facts are tests which are always true. They test invariant conditions.
// Theories are tests which are only true for a particular set of data.

// https://xunit.github.io/docs/getting-started-dnx.html1

namespace Tests
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

    [Fact]
    public void PassingTest()
    {
      Assert.Equal(4, Add(2, 2));
    }

    [Fact]
    public void FailingTest()
    {
      Assert.Equal(5, Add(2, 2));
    }

    int Add(int x, int y)
    {
      return x + y;
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void MyFirstTheory(int value)
    {
      Assert.True(IsOdd(value));
    }

    bool IsOdd(int value)
    {
      return value % 2 == 1;
    }

  }
}