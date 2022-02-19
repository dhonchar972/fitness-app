using FitnessApp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = "Aboba643";
            var activityName = Guid.NewGuid().ToString();
            var random = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurentUser);
            var activity = new Activity(activityName, random.Next(50, 500));

            //Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddMinutes(30));

            //Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}