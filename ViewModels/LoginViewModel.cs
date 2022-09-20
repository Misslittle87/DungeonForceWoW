﻿using System.ComponentModel.DataAnnotations;

namespace DungeonForceWoW.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}