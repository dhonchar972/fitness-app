using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Threading;

namespace FitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our new fitness app!");
            Thread.Sleep(3000);
            Console.Clear();
            UserController userController;
            EatingController eatingController;
            while (true)
            {
                Console.Write("Please enter your username: ");
                string name = Console.ReadLine();
                if (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot by empty");
                }
                else if (name.Length < 8 || name.Length > 26)
                {
                    Console.WriteLine("Name cannot be smaller than 8 symbols and longer than 26");
                }
                userController = new UserController(name);
                eatingController = new EatingController(userController.CurentUser);
                break;
            }

            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDate();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("F1 - Input eating.");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.F1)
            {
                var food = EnterEating();
                eatingController.Add(food.Food, food.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Input food name: ");
            var name = Console.ReadLine();
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var calories = ParseDouble("calories");
            var weight = ParseDouble("weight");
            var product = new Food(name, proteins, fats, carbohydrates, calories);
            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter birth date (mm.dd.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
            }
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {name} format");
                }
            }
        }
    }
}
