using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace FitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var culture = CultureInfo.CurrentCulture;
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", 
                typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Thread.Sleep(3000);
            Console.Clear();
            UserController userController;
            EatingController eatingController;
            ExerciseController exerciseController;
            while (true)
            {
                Console.Write(resourceManager.GetString("NameInput", culture));
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
                exerciseController = new ExerciseController(userController.CurentUser);
                break;
            }

            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDate("birth date");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurentUser);
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("F1 - Enter eating.");
                Console.WriteLine("F2 - Input exercise.");
                Console.WriteLine("F10 - Quit.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        var food = EnterEating();
                        eatingController.Add(food.Food, food.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.F2:
                        var exerciseParameters = EnterExercises();
                        exerciseController.Add(exerciseParameters.activity, exerciseParameters.start,
                            exerciseParameters.finish);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to " +
                                $"{item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.F10:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        private static (TimeOnly start, TimeOnly finish, Activity activity) EnterExercises()
        {
            Console.Write("Enter exercise name: ");
            var name = Console.ReadLine();
            var caloriesPerMinute = ParseDouble("calories per minute");
            var start = ParseTime("exercise start time");
            var finish = ParseTime("exercise finish time");
            var activity = new Activity(name, caloriesPerMinute);
            return (start, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter food name: ");
            var name = Console.ReadLine();
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var calories = ParseDouble("calories");
            var weight = ParseDouble("weight");
            var product = new Food(name, proteins, fats, carbohydrates, calories);
            return (Food: product, Weight: weight);
        }
        private static DateOnly ParseDate(string value)
        {
            DateOnly birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (mm.dd.yyyy): ");
                if (DateOnly.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
            }
        }
        private static TimeOnly ParseTime(string value)
        {
            TimeOnly birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (mm.dd.yyyy): ");
                if (TimeOnly.TryParse(Console.ReadLine(), out birthDate))
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
