using System.Linq;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class IngredientControllerTest
  {
    [TestMethod]
    public void can_get_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Ingredient>> mock = new Mock<ICommonRepository<Ingredient>>();

      mock.Setup(m => m.Data).Returns(new []
      { 
        new Ingredient {IngredientID = 1, Amount = 1},
        new Ingredient {IngredientID = 2, Amount = 2},
        new Ingredient {IngredientID = 3, Amount = 3}
      });
      // Arrange - create a controller
      IngredientController target = new IngredientController(mock.Object);
      // Action
      Ingredient[] result = target.GetIngredients().ToArray();
      // Assert
      Assert.AreEqual(result.Length, 3);
      Assert.AreEqual(1, result[0].Amount);
      Assert.AreEqual(2, result[1].Amount);
      Assert.AreEqual(3, result[2].Amount);
    }

    [TestMethod]
    public void  can_get_data_by()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Ingredient>> mock = new Mock<ICommonRepository<Ingredient>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Ingredient {IngredientID = 1, Amount = 1},
        new Ingredient {IngredientID = 2, Amount = 2},
        new Ingredient {IngredientID = 3, Amount = 3}
      });
      // Arrange - create a controller
      IngredientController target = new IngredientController(mock.Object);
      // Arrange - create a search tag
      Ingredient ingredient = new Ingredient() {Amount = 2};
      // Action
      Ingredient[] result = target.GetIngredientBy(ingredient).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].IngredientID);

    }

    [TestMethod]
    public void can_save_Ingredient()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<Ingredient>> mock = new Mock<ICommonRepository<Ingredient>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Ingredient {IngredientID = 1, Amount = 1},
        new Ingredient {IngredientID = 2, Amount = 2},
        new Ingredient {IngredientID = 3, Amount = 3}
      });
      // Arrange - create a controller
      IngredientController target = new IngredientController(mock.Object);
      Ingredient ingredient = new Ingredient() {IngredientID = 2, Amount = 66};
      // Act - try to save the product
      string result = target.SaveIngredient(ingredient);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(ingredient));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_Ingredient()
    {
      // Arrange - create an Ingredient
      Ingredient prod = new Ingredient { IngredientID = 2, Amount = 66 };
      // Arrange - create the mock repository
      Mock<ICommonRepository<Ingredient>> mock = new Mock<ICommonRepository<Ingredient>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new Ingredient {IngredientID = 1, Amount = 1},
        new Ingredient {IngredientID = 2, Amount = 2},
        new Ingredient {IngredientID = 3, Amount = 3}
      });
      // Arrange - create a controller
      IngredientController target = new IngredientController(mock.Object);
      // Act - delete the Ingredient
      target.RemoveIngredient(prod.IngredientID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.IngredientID));
    }
  }
}
