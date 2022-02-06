using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitnOne.BL.Controller.Tests
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
            var rand = new Random();
            var userName = rand.Next(100000, int.MaxValue).ToString();
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
    }
}