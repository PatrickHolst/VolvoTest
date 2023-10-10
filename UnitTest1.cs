

using Microsoft.AspNetCore.Mvc;
using VolvoREST.Controllers;
using VolvoREST.Data;
using VolvoREST.Models;

namespace VolvoREST.Tests
{
    [TestClass]
    public class NumberControllerTests
    {
        [TestMethod]
        public void PostNumber_ValidInput_ReturnsOk()
        {
            // Arrange
            var numberStore = new NumberList();
            var controller = new NumberController(numberStore);
            var input = new NumberInput { Number = 42 };

            // Act
            var result = controller.PostNumber(input) as OkObjectResult;

            // Assert
            if (result != null)
            {
                var value = result.Value as string;
                if (value != null)
                {
                    // Check if the response contains the expected message
                    if (value == "Number 42 added")
                    {
                        // Test passed
                        return;
                    }
                }
            }

            // Test failed
            throw new Exception("Test failed.");
        }
    }
}