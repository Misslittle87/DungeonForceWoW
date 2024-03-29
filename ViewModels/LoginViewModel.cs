﻿using System.ComponentModel.DataAnnotations;

namespace DungeonForceWoW.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me!")]
        public bool RemeberMe { get; set; }
    }
}
