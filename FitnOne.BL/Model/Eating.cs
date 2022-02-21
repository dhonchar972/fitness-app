
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
        public int Id { get; set; }
        /// <summary>
        /// Eating time.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Food and it quantity.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; } //EROR!!!!!!
        /// <summary>
        /// User.
        /// </summary>
        public int UserId { get; set; }
        public virtual User User { get; set; }
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
        //public void Remove(Food food)
        //{
        //    var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
        //    if (product == null)
        //    {
        //        Console.WriteLine("Food not found"); ;
        //    }
        //    else
        //    {
        //        Foods.Remove(food);
        //    }
        //}
    }
}
