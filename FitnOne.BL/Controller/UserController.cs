using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// List of application users.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Curent user.
        /// </summary>
        public User CurentUser { get; }
        /// <summary>
        /// Stores the state of user (new or registered).
        /// </summary>
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
            else if(userName.Length < 5 || userName.Length > 20)
            {
                throw new ArgumentException("Name cannot be smaller than 5 symbols and longer than 20", nameof(userName));
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
                if (fileStream.Length > 0 && formatter.Deserialize(fileStream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        /// <summary>
        /// Receives user data, enters and saves it.
        /// </summary>
        /// <param name="genderName">User gender.</param>
        /// <param name="birthDate">User birth date.</param>
        /// <param name="weight">User weight.</param>
        /// <param name="height">User height.</param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: Add checkup.
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
