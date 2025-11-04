using System;
using System.Text.RegularExpressions;
namespace Domain
{
    public abstract class Person : IEntity
    {
        private static Regex nameRegex = new Regex(@"^[A-Za-zА-Яа-яЁёЇїІіЄєҐґ'-]{1,50}$");
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public abstract string TypeName { get; }
        public abstract string UniqueId { get; }

        protected Person(string firstName, string lastName)
        {
            if (!nameRegex.IsMatch(firstName)) throw new ArgumentException("Invalid firstname");
            if (!nameRegex.IsMatch(lastName)) throw new ArgumentException("Invalid lastname");
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{TypeName} {FirstName} {LastName}";
        }
    }
}
