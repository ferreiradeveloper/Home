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

            [Required]
            [Display(Name = "Contraseña")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}", MinimumLength = 8)]
            public string Password { get; set; }

            
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Error: Contraceña y Confirmacion no coinciden")]
            public string ConfirmarPassword { get; set; }
        }

        public IActionResult OnPost()
        {
            var data = Input;
            return Page();
        }
        
    }
}
