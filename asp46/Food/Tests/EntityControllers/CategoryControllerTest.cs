using System.Linq;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class CategoryControllerTest
  {
    [TestMethod]
    public void can_get_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Category>> mock = new Mock<ICommonRepository<Category>>();

      mock.Setup(m => m.Data).Returns(new []
      {
        new Category {CategoryID = 1, Name = "P1"},
        new Category {CategoryID = 2, Name = "P2"},
        new Category {CategoryID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      CategoryController target = new CategoryController(mock.Object);
      // Action
      Category[] result = target.GetCategories().ToArray();
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
      Mock<ICommonRepository<Category>> mock = new Mock<ICommonRepository<Category>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Category {CategoryID = 1, Name = "P1"},
        new Category {CategoryID = 2, Name = "P2"},
        new Category {CategoryID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      CategoryController target = new CategoryController(mock.Object);
      // Arrange - create a search tag
      Category category = new Category() {Name = "P2"};
      // Action
      Category[] result = target.GetCategoryBy(category).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].CategoryID);

    }

    [TestMethod]
    public void can_save_Category()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Category>> mock = new Mock<ICommonRepository<Category>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Category {CategoryID = 1, Name = "P1"},
        new Category {CategoryID = 2, Name = "P2"},
        new Category {CategoryID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      CategoryController target = new CategoryController(mock.Object);
      Category category = new Category() {CategoryID = 2, Name = "P33"};
      // Act - try to save the product
      string result = target.SaveCategory(category);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(category));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_Category()
    {
      // Arrange - create an Category
      Category prod = new Category { CategoryID = 2, Name = "Test" };
      // Arrange - create the mock repository
      Mock<ICommonRepository<Category>> mock = new Mock<ICommonRepository<Category>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Category {CategoryID = 1, Name = "P1"},
        new Category {CategoryID = 2, Name = "P2"},
        new Category {CategoryID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      CategoryController target = new CategoryController(mock.Object);
      // Act - delete the Category
      target.RemoveCategory(prod.CategoryID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.CategoryID));
    }
  }
}
