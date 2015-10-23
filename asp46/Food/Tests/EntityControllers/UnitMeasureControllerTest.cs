using System.Linq;
using API.Controllers.Entities;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.EntityControllers
{
  [TestClass]
  public class UnitMeasureControllerTest
  { 
    [TestMethod]
    public void can_get_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<UnitMeasure>> mock = new Mock<ICommonRepository<UnitMeasure>>();

      mock.Setup(m => m.Data).Returns(new []
      {
        new UnitMeasure {UnitMeasureID = 1, Name = "P1"},
        new UnitMeasure {UnitMeasureID = 2, Name = "P2"},
        new UnitMeasure {UnitMeasureID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      UnitMeasureController target = new UnitMeasureController(mock.Object);
      // Action
      UnitMeasure[] result = target.GetUnitsMeasure().ToArray();
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
      Mock<ICommonRepository<UnitMeasure>> mock = new Mock<ICommonRepository<UnitMeasure>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UnitMeasure {UnitMeasureID = 1, Name = "P1"},
        new UnitMeasure {UnitMeasureID = 2, Name = "P2"},
        new UnitMeasure {UnitMeasureID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      UnitMeasureController target = new UnitMeasureController(mock.Object);
      // Arrange - create a search tag
      UnitMeasure UnitMeasure = new UnitMeasure() {Name = "P2"};
      // Action
      UnitMeasure[] result = target.GetUnitMeasureBy(UnitMeasure).ToArray();
      // Assert
      Assert.AreEqual(result.Length, 1);
      Assert.AreEqual(2, result[0].UnitMeasureID);

    }

    [TestMethod]
    public void can_save_data()
    {
      // Arrange - create the mock repository
      Mock<ICommonRepository<UnitMeasure>> mock = new Mock<ICommonRepository<UnitMeasure>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UnitMeasure {UnitMeasureID = 1, Name = "P1"},
        new UnitMeasure {UnitMeasureID = 2, Name = "P2"},
        new UnitMeasure {UnitMeasureID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      UnitMeasureController target = new UnitMeasureController(mock.Object);
      UnitMeasure unitMeasure = new UnitMeasure() {UnitMeasureID = 2, Name = "P33"};
      // Act - try to save the product
      string result = target.SaveUnitMeasure(unitMeasure);
      // Assert - check that the repository was called
      mock.Verify(m => m.SaveData(unitMeasure));
      // Assert - check the method result type
      Assert.IsInstanceOfType(result, typeof(string));
    }

    [TestMethod]
    public void can_remove_data()
    {
      // Arrange - create an UnitMeasure
      UnitMeasure prod = new UnitMeasure { UnitMeasureID = 2, Name = "Test" };
      // Arrange - create the mock repository
      Mock<ICommonRepository<UnitMeasure>> mock = new Mock<ICommonRepository<UnitMeasure>>();

      mock.Setup(m => m.Data).Returns(new[]
      {
        new UnitMeasure {UnitMeasureID = 1, Name = "P1"},
        new UnitMeasure {UnitMeasureID = 2, Name = "P2"},
        new UnitMeasure {UnitMeasureID = 3, Name = "P3"}
      });
      // Arrange - create a controller
      UnitMeasureController target = new UnitMeasureController(mock.Object);
      // Act - delete the UnitMeasure
      target.RemoveUnitMeasure(prod.UnitMeasureID);
      // Assert - ensure that the repository delete method was
      // called with the correct Product
      mock.Verify(m => m.DeleteData(prod.UnitMeasureID));
    }
  }
}
