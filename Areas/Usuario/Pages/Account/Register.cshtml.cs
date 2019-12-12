using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            [Required(ErrorMessage ="Email es Requerido")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password es Requerido")]
            [Display(Name = "Contraseña")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}", MinimumLength = 8)]
            public string Password { get; set; }

            
            [Required(ErrorMessage = "Confirmacion de Pasword es Requerida")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Error: Contraceña y Confirmacion no coinciden")]
            public string ConfirmarPassword { get; set; }

            [Required]
            public string ErrorMessage { get; set; }

            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                ModelState.AddModelError("Input.Email","Error en el server");
            }
            var data = Input;
            return Page();
        }
        
    }
}
