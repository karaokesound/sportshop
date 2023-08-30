﻿namespace Sportshop.Entity.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string City { get; set; }

        public int Age { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime TokenCreated { get; set; }

        public DateTime TokenExpires { get; set; }

        public UserEntity(string username, string city, int age)
        {
            // Id property is adding automatically by the EF (set in the UserEntityConfiguration.cs)
            Id = Guid.NewGuid();
            Username = username;
            City = city;
            Age = age;
        }
    }
}
