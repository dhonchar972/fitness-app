using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "D:\\FitnessApp\\FitnOne.BL\\Sources\\foods.dat";
        private const string EATINGS_FILE_NAME = "D:\\FitnessApp\\FitnOne.BL\\Sources\\eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cannot by empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product != null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return base.Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return base.Load<Food>() ?? new List<Food>();
        }
        private void Save()
        {
            base.Save(Foods);
            base.Save(new List<Eating>() { Eating });
        }
    }
}
