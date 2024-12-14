﻿using System.ComponentModel.DataAnnotations;

namespace Library.Services.Mapping.DTOs.User
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}