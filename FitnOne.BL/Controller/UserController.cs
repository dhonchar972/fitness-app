
using FitnOne.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnOne.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Application user.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Сreating a new user controller.
        /// </summary>
        /// <param name="user">User.</param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            //TODO: Add check.
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fileStream) is User user)
                {
                    User = user;
                }
            }   // TODO: Add solution to situation when user was't read.
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, User);
            }
        }
        
    }
}
