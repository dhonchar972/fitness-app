using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            //TODO: add
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = "Aboba287";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controllerTwo = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controllerTwo.CurentUser.Name);
            Assert.AreEqual(birthDate, controllerTwo.CurentUser.BirthDate);
            Assert.AreEqual(weight, controllerTwo.CurentUser.Weight);
            Assert.AreEqual(height, controllerTwo.CurentUser.Height);
            Assert.AreEqual(gender, controllerTwo.CurentUser.Gender.Name);
        }
        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = "Aboba1111";

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurentUser.Name);
        }
    }
}