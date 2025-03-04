﻿namespace SchedHoliday.Models
{
    public class Authentication
    { 
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }

    public class OAuth
    {
        public string Token { get; set; }
    }
}
