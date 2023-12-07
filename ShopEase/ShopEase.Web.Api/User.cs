﻿namespace ShopEase.Web.Api
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string EmailId { get; set; }

        public required string Mobile { get; set; }

        public required string Password { get; set; }

        public string Type { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}