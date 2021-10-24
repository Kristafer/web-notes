﻿using WebNotesData.Entities;

namespace WebNotesApplication.Models
{
    public class AuthenticateResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

    }
}
