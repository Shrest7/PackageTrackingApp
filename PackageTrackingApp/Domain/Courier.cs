using PackageTrackingApp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domain
{
    public class Courier
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfEmployment { get; set; } = null;

        public Courier(string firstName, string lastName,
            DateTime dateOfBirth)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
        }

        private void SetLastName(string lastName)
        {
            if (!lastName.All(char.IsLetter))
            {
                throw new Exception("Last name must contain only letters.");
            }

            LastName = lastName;
        }

        private void SetFirstName(string firstName)
        {
            if (!firstName.All(char.IsLetter))
            {
                throw new Exception("First name must contain only letters.");
            }

            FirstName = firstName;
        }

        private void SetDateOfBirth(DateTime dateOfBirth)
        {
            var age = dateOfBirth.CalculateAge();

            if(age < 18)
            {
                throw new Exception("Courier must be at least 18 years old");
            }

            DateOfBirth = dateOfBirth;
        }
    }
}
