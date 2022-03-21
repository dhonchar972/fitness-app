using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "D:\\FitnessApp\\FitnOne.BL\\Sources\\users.dat";
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
            else if (userName.Length < 8 || userName.Length > 26)
            {
                throw new ArgumentException("Name cannot be smaller than 8 symbols and longer than 26", nameof(userName));
            }
            Users = GetUsersData();
            CurentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurentUser == null)
            {
                CurentUser = new User(userName);
                Users.Add(CurentUser);
                IsNewUser = true;
            }
        }
        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns>New list.</returns>
        private List<User> GetUsersData()
        {
            return base.Load<User>() ?? new List<User>();
        }
        /// <summary>
        /// Receives user data, enters and saves it.
        /// </summary>
        /// <param name="genderName">User gender.</param>
        /// <param name="birthDate">User birth date.</param>
        /// <param name="weight">User weight.</param>
        /// <param name="height">User height.</param>
        public void SetNewUserData(string genderName, DateOnly birthDate, double weight = 1, double height = 1)
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
            base.Save(Users);
        }
    }
}
