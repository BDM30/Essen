using System.Linq;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class RecipeControllerTest
  {
    [TestMethod]
    public void can_get_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Recipe>> mock = new Mock<ICommonRepository<Recipe>>();

      mock.Setup(m => m.Data).Returns(new []
      {
        new Recipe {RecipeID = 1, Name = "P1"},
        new Recipe {RecipeID = 2, Name = "P2"},
        new Recipe {RecipeID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      RecipeController target = new RecipeController(mock.Object);
      // Action
      Recipe[] result = target.GetRecipes().ToArray();
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
      Mock<ICommonRepository<Recipe>> mock = new Mock<ICommonRepository<Recipe>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Recipe {RecipeID = 1, Name = "P1"},
        new Recipe {RecipeID = 2, Name = "P2"},
        new Recipe {RecipeID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      RecipeController target = new RecipeController(mock.Object);
      // Arrange - create a search tag
      Recipe recipe = new Recipe() {Name = "P2"};
      // Action
      Recipe[] result = target.GetRecipeBy(recipe).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].RecipeID);

    }

    [TestMethod]
    public void can_save_Recipe()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Recipe>> mock = new Mock<ICommonRepository<Recipe>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Recipe {RecipeID = 1, Name = "P1"},
        new Recipe {RecipeID = 2, Name = "P2"},
        new Recipe {RecipeID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      RecipeController target = new RecipeController(mock.Object);
      Recipe recipe = new Recipe() {RecipeID = 2, Name = "P33"};
      // Act - try to save the product
      string result = target.SaveRecipe(recipe);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(recipe));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_Recipe()
    {
      // Arrange - create an Recipe
      Recipe prod = new Recipe { RecipeID = 2, Name = "Test" };
      // Arrange - create the mock repository
      Mock<ICommonRepository<Recipe>> mock = new Mock<ICommonRepository<Recipe>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Recipe {RecipeID = 1, Name = "P1"},
        new Recipe {RecipeID = 2, Name = "P2"},
        new Recipe {RecipeID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      RecipeController target = new RecipeController(mock.Object);
      // Act - delete the Recipe
      target.RemoveRecipe(prod.RecipeID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.RecipeID));
    }
  }
}
