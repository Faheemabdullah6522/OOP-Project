using System;

namespace Window_Forms.Models
{
    /// <summary>
    /// Abstract base class representing a person in the system
    /// Demonstrates abstraction and inheritance
    /// </summary>
    public abstract class Person
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Abstract method to get role - demonstrates polymorphism
        /// </summary>
        public abstract string GetRole();

        /// <summary>
        /// Virtual method to get display name
        /// </summary>
        public virtual string GetDisplayName()
        {
            return $"{FullName} ({GetRole()})";
        }

        /// <summary>
        /// Virtual method to validate person data
        /// </summary>
        public virtual bool ValidateBasicInfo()
        {
            return !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(FullName) &&
                   !string.IsNullOrWhiteSpace(Phone);
        }

        protected Person()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
