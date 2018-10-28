﻿using System.ComponentModel.DataAnnotations;

namespace TekeriumCommerce.Module.Core.Areas.Core.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}