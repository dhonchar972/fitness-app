
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Eating.
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Eating time.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// Food and it quantity.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Creating a new eating list.
        /// </summary>
        /// <param name="user">User.</param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User cannot by empty", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Add food and it quantity to list.
        /// </summary>
        /// <param name="food">Food.</param>
        /// <param name="weight">Weight.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }

        }
        /// <summary>
        /// Remove food from list.
        /// </summary>
        /// <param name="food"></param>
        public void Remove(Food food)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Console.WriteLine("Food not found"); ;
            }
            else
            {
                Foods.Remove(food);
            }
        }
    }
}
