
using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Food.
    /// </summary>
    [Serializable]
    public class Food
    {
        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amount of calories in 100 grams of product.
        /// </summary>
        public double Calories { get; set; }
        /// <summary>
        /// Amount of proteins.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Amount of fats.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Amount of carbohydrates.
        /// </summary>
        public double Carbohydrates { get; set; }
        #endregion        
        /// <summary>
        /// Create food product.
        /// </summary>
        /// <param name="name">Food name.</param>
        public virtual ICollection<Eating> Eatings { get; set; }
        public Food() { }
        public Food(string name) : this(name, 0.1, 0.1, 0.1, 0.1) { }
        /// <summary>
        /// Create food product.
        /// </summary>
        /// <param name="name">Food name.</param>
        /// <param name="proteins">Amount of proteins.</param>
        /// <param name="fats">Amount of fats.</param>
        /// <param name="carbohydrates">Amount of carbohydrates.</param>
        /// <param name="calories">Amount of calories.</param>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }
            Name = name;
            Calories = FoodPropertiesCheck(calories);
            Proteins = FoodPropertiesCheck(proteins);
            Fats = FoodPropertiesCheck(fats);
            Carbohydrates = FoodPropertiesCheck(carbohydrates);

        }
        private double FoodPropertiesCheck(double name)
        {
            if (name <= 0.0)
            {
                throw new ArgumentException($"Amount of food {name} must be greater or equal zero", nameof(name));
            }
            return name / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
