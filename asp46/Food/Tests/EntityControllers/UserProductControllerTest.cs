using System.Linq;
using API.Controllers;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class UserProductControllerTest
  { 
    [TestMethod]
    public void can_get_data()
    { 
      // Arrange - create the mock repository
      Mock<ICommonRepository<UserProduct>> mock = new Mock<ICommonRepository<UserProduct>>();

      mock.Setup(m => m.Data).Returns(new []
      {
        new UserProduct {UserProductID = 1, ExpirationDate = "P1"},
        new UserProduct {UserProductID = 2, ExpirationDate = "P2"},
        new UserProduct {UserProductID = 3, ExpirationDate = "P3"}
      });
      // Arrange - create a controller
      UserProductController target = new UserProductController(mock.Object);
      // Action
      UserProduct[] result = target.GetUserProducts().ToArray();
      // Assert
      Assert.AreEqual(result.Length, 3);
      Assert.AreEqual("P1", result[0].ExpirationDate);
      Assert.AreEqual("P2", result[1].ExpirationDate);
      Assert.AreEqual("P3", result[2].ExpirationDate);
    }

    [TestMethod]
    public void  can_get_data_by()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<UserProduct>> mock = new Mock<ICommonRepository<UserProduct>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UserProduct {UserProductID = 1, ExpirationDate = "P1"},
        new UserProduct {UserProductID = 2, ExpirationDate = "P2"},
        new UserProduct {UserProductID = 3, ExpirationDate = "P3"}
      });
      // Arrange - create a controller
      UserProductController target = new UserProductController(mock.Object);
      // Arrange - create a search tag
      UserProduct userProduct = new UserProduct() {ExpirationDate = "P2"};
      // Action
      UserProduct[] result = target.GetUserProductBy(userProduct).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].UserProductID);

    }

    [TestMethod]
    public void can_save_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<UserProduct>> mock = new Mock<ICommonRepository<UserProduct>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UserProduct {UserProductID = 1, ExpirationDate = "P1"},
        new UserProduct {UserProductID = 2, ExpirationDate = "P2"},
        new UserProduct {UserProductID = 3, ExpirationDate = "P3"}
      });
      // Arrange - create a controller
      UserProductController target = new UserProductController(mock.Object);
      UserProduct UserProduct = new UserProduct() {UserProductID = 2, ExpirationDate = "P33"};
      // Act - try to save the product
      string result = target.SaveUserProduct(UserProduct);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(UserProduct));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_data()
    {
      // Arrange - create an UserProduct
      UserProduct prod = new UserProduct { UserProductID = 2, ExpirationDate = "Test" };
      // Arrange - create the mock repository
      Mock<ICommonRepository<UserProduct>> mock = new Mock<ICommonRepository<UserProduct>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UserProduct {UserProductID = 1, ExpirationDate = "P1"},
        new UserProduct {UserProductID = 2, ExpirationDate = "P2"},
        new UserProduct {UserProductID = 3, ExpirationDate = "P3"}
      });
      // Arrange - create a controller
      UserProductController target = new UserProductController(mock.Object);
      // Act - delete the UserProduct
      target.RemoveUserProduct(prod.UserProductID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.UserProductID));
    }
  }
}
