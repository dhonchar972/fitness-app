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
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                userController.SetNewUserData();
            }
            Console.WriteLine(userController.CurentUser);
            Console.ReadLine();
        }
    }
}
