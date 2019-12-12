using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Usuarios.Areas.Usuario.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet(string data)
        {
           
        }

        [BindProperty]
        public  InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
        
    }
}
