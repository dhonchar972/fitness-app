using FitnOne.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public List<User> Users { get; }
        public User CurentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Сreating a new user controller.
        /// </summary>
        /// <param name="user">User.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name cannot by null or empty", nameof(userName));
            }
            Users = GetUsersData();
            CurentUser = Users.SingleOrDefault(user => user.Name == userName);
            if(CurentUser == null)
            {
                CurentUser = new User(userName);
                Users.Add(CurentUser);
                IsNewUser = true;
                Save();
            }
            
        }
        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns>New list.</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fileStream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Check
            CurentUser.Gender = new Gender(genderName);
            CurentUser.BirthDate = birthDate;
            CurentUser.Weight = weight;
            CurentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        private void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, Users);
            }
        }
        
    }
}
