using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public class User
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        [Key]
        public Guid Guid { get; protected set; }
        [Required]
        [MaxLength(25)]
        public string Login { get; protected set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string Email { get; protected set; }
        public string Role { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public DateTime CreatedAt { get; init; }
        public DateTime LastUpdated { get; protected set; }

        public User()
        {

        }

        public User(string email, string login, string role,
            string password, string confirmPassword, DateTime dateOfBirth,
            IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            CreatedAt = DateTime.UtcNow;
            SetLogin(login);
            SetEmail(email);
            SetRole(role);
            SetPassword(password, confirmPassword);
            SetDateOfBirth(dateOfBirth);
        }

        private void SetDateOfBirth(DateTime dateOfBirth)
        {
            var age = dateOfBirth.CalculateAge();

            if(age < 12)
            {
                throw new Exception("You need to be at least 12 years old to use" +
                    "our services.");
            }

            DateOfBirth = dateOfBirth;
            LastUpdated = DateTime.UtcNow;
        }


        private void SetLogin(string login)
        {
            if(string.Equals(Login, login))
            {
                return;
            }

            if(login.Length < 4)
            {
                throw new Exception("Login must be at least 4 characters long");
            }

            Login = login;
            LastUpdated = DateTime.UtcNow;
        }

        private void SetPassword(string password, string confirmPassword)
        {
            if (string.Equals(Password, password))
            {
                return;
            }

            if(password.Length < 6)
            {
                throw new Exception("Password must be at least 6 characters long");
            }

            if (!password.IsValidPassword())
            {
                throw new Exception("Please choose a stronger password");
            }

            if (!string.Equals(password, confirmPassword))
            {
                throw new Exception("Passwords do not match!");
            }

            var hashedPassword = _passwordHasher.HashPassword(this, password);

            Password = hashedPassword;
            LastUpdated = DateTime.UtcNow;
        }

        private void SetRole(string role)
        {
            if(string.Equals(role, Role))
            {
                return;
            }

            if(!string.Equals(role, Roles.Admin) 
                && !string.Equals(role, Roles.User))
            {
                throw new Exception($"Role \"{role}\" does not exist.");
            }

            Role = role;
            LastUpdated = DateTime.UtcNow;
        }

        private void SetEmail(string email)
        {
            if(string.Equals(Email, email))
            {
                return;
            }

            if (!email.IsEmail())
            {
                throw new Exception("Email is not valid.");
            }

            Email = email;
            LastUpdated = DateTime.UtcNow;
        }
    }
}
