
using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of gender.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="name">Gender name.</param>
        public virtual ICollection<User> Users { get; set; } //APPPPPAAAAA
        public Gender() { }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return obj is Gender gender &&
                   Name == gender.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
