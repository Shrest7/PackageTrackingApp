using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PackageTrackingApp.Extensions;

namespace PackageTrackingApp.Core.Domains
{
    public class Seller
    {
        private float? _rating;
        [Key]
        public Guid Guid { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Package> PackagesSold { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Email { get; protected set; }
        public float? Rating
        {
            get => _rating;
            protected set
            {
                if(value < 1 || value > 5)
                {
                    throw new Exception("Rating must be in range from 1 to 5!");
                }

                _rating = value;
            }
        }

        public Seller(string email, string phoneNumber)
        {
            Guid = Guid.NewGuid();
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
            Rating = null;
        }

        private void SetPhoneNumber(string phoneNumber)
        {
            if(PhoneNumber == phoneNumber)
            {
                return;
            }
            if (!phoneNumber.IsPhoneNumber())
            {
                throw new ArgumentException("Invalid phone number.", nameof(phoneNumber));
            }

            PhoneNumber = phoneNumber;
        }

        private void SetEmail(string email)
        {
            if(Email == email)
            {
                return;
            }
            if (!email.IsEmail())
            {
                throw new ArgumentException("Invalid email.", nameof(email));
            }

            Email = email;
        }
    }
}
