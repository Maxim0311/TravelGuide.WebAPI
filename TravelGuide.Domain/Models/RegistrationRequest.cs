﻿
namespace TravelGuide.Domain.Models
{
    public class RegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
