using VolvoREST.Controllers;
using VolvoREST.Data;
using VolvoREST.Models;
using Microsoft.AspNetCore.Mvc;

namespace VolvoREST.Tests
{
    [TestClass]
    public class NumberControllerTests
    {
        [TestMethod]
        public void PostNumber_WithNewNumber_ShouldReturnOk()
        {
            // Arrange
            var numberList = new NumberList();
            var controller = new NumberController(numberList);
            var input = new NumberInput { Number = 5 };

            // Act
            var result = controller.PostNumber(input);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void PostNumber_WithDuplicateNumber_ShouldReturnConflict()
        {
            // Arrange
            var numberList = new NumberList();
            numberList.AddNumber(5);
            var controller = new NumberController(numberList);
            var input = new NumberInput { Number = 5 };

            // Act
            var result = controller.PostNumber(input);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
        }
    }
}