
using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Food.
    /// </summary>
    public class Food
    {
        #region Properties
        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Amount of proteins.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Amount of fats.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Amount of carbohydrates.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Amount of calories in 100 grams of product.
        /// </summary>
        public double Calories { get; }
        #endregion        
        /// <summary>
        /// Create food product.
        /// </summary>
        /// <param name="name">Food name.</param>
        public Food(string name) : this(name, 0.1, 0.1, 0.1, 0.1){}
        /// <summary>
        /// Create food product.
        /// </summary>
        /// <param name="name">Food name.</param>
        /// <param name="proteins">Amount of proteins.</param>
        /// <param name="fats">Amount of fats.</param>
        /// <param name="carbohydrates">Amount of carbohydrates.</param>
        /// <param name="calories">Amount of calories.</param>
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }
            Name = name;
            Proteins = FoodPropertiesCheck(proteins);
            Fats = FoodPropertiesCheck(fats);
            Carbohydrates = FoodPropertiesCheck(carbohydrates);
            Calories = FoodPropertiesCheck(calories);
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
