using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity(string name, double caloriesPerMinute)
        {
            //Control
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public Activity() { }
        public override string ToString()
        {
            return Name;
        }
    }
}
