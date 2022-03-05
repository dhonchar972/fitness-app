﻿
using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]
    public class User
    {

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User's gender.
        /// </summary>
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }//Need fix
        /// <summary>
        /// User's birthday.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;//Need fix
        /// <summary>
        /// User's weight.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User's height.
        /// </summary>
        public double Height { get; set; }

        /* 
         * DateTime nowDate = DateTime.Today;
         * int age = nowDate.Year - birthDate.Year;
         * if(birthDate > nowDate.AddYears(-age)) age--;
         */
        /// <summary>
        /// User's age.
        /// </summary>
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">User's name.</param>
        /// <param name="gender">User's gender.</param>
        /// <param name="birthDate">User's birthday.</param>
        /// <param name="weight">User's weight.</param>
        /// <param name="height">User's height.</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Parameter sheck
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null or empty", nameof(gender));
            }
            if ((birthDate < DateTime.Parse("01.01.1900")) || (birthDate >= DateTime.Now))
            {
                throw new ArgumentException("Invalid date input", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight must be equal or greater than zero", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height must be equal or greater than zero", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User() { }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            //TODO: Change implementations.
            return Name + " " + Age;
        }
    }
}
