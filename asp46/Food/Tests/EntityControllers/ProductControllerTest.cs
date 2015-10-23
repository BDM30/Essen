using System.Linq;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class ProductControllerTest
  {
    [TestMethod]
    public void can_get_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Product>> mock = new Mock<ICommonRepository<Product>>();

      mock.Setup(m => m.Data).Returns(new []
      {
        new Product {ProductID = 1, Name = "P1"},
        new Product {ProductID = 2, Name = "P2"},
        new Product {ProductID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      ProductController target = new ProductController(mock.Object);
      // Action
      Product[] result = target.GetProducts().ToArray();
      // Assert
      Assert.AreEqual(result.Length, 3);
      Assert.AreEqual("P1", result[0].Name);
      Assert.AreEqual("P2", result[1].Name);
      Assert.AreEqual("P3", result[2].Name);
    }

    [TestMethod]
    public void  can_get_data_by()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Product>> mock = new Mock<ICommonRepository<Product>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Product {ProductID = 1, Name = "P1"},
        new Product {ProductID = 2, Name = "P2"},
        new Product {ProductID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      ProductController target = new ProductController(mock.Object);
      // Arrange - create a search tag
      Product product = new Product() {Name = "P2"};
      // Action
      Product[] result = target.GetProductBy(product).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].ProductID);

    }

    [TestMethod]
    public void can_save_Product()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Product>> mock = new Mock<ICommonRepository<Product>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Product {ProductID = 1, Name = "P1"},
        new Product {ProductID = 2, Name = "P2"},
        new Product {ProductID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      ProductController target = new ProductController(mock.Object);
      Product product = new Product() {ProductID = 2, Name = "P33"};
      // Act - try to save the product
      string result = target.SaveProduct(product);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(product));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_Product()
    {
      // Arrange - create an Product
      Product prod = new Product { ProductID = 2, Name = "Test" };
      // Arrange - create the mock repository
      Mock<ICommonRepository<Product>> mock = new Mock<ICommonRepository<Product>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Product {ProductID = 1, Name = "P1"},
        new Product {ProductID = 2, Name = "P2"},
        new Product {ProductID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      ProductController target = new ProductController(mock.Object);
      // Act - delete the Product
      target.RemoveProduct(prod.ProductID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.ProductID));
    }
  }
}
