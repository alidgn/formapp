using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}