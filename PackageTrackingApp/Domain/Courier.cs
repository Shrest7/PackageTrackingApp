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
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
