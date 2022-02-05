using FitnOne.BL.Controller;
using System;

namespace FitnOne.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our new fitness app!");
            Console.ReadLine();
            Console.WriteLine("Please enter your username");
            var name = Console.ReadLine();
            //if(name.Length < 5) { Console.WriteLine("Wrong name, try again"); }
            Console.WriteLine("Please enter your gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Please enter date of birth");
            var birthDate = DateTime.Parse(Console.ReadLine());//TODO: Fix.
            Console.WriteLine("Please enter your weigth");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your height");
            var height = double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
