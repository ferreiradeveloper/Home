using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Usuarios.Areas.Usuario.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private static InputModel _input = null;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public void OnGet(string data)
        {
           if (_input != null)
            {
                Input = _input;
            }
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
            [Display(Name = "Contraseņa")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}", MinimumLength = 8)]
            public string Password { get; set; }

            
            [Required(ErrorMessage = "Confirmacion de Pasword es Requerida")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Error: Contraceņa y Confirmacion no coinciden")]
            public string ConfirmarPassword { get; set; }

            //[Required]
            public string ErrorMessage { get; set; }            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await RegisterUserAsync())
            {
                return Redirect("/Principal/Principal?area=Principal");
            }
            else
            {
                return Redirect("/Usuario/Register");
            }
            
            
        }


        private async Task<bool> RegisterUserAsync()
        {
            var run = false;

            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                if (userList.Count.Equals(0))
                {
                    var user = new IdentityUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email
                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        run = true;
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            Input = new InputModel
                            {
                                ErrorMessage = item.Description,
                                Email = Input.Email
                            };
                        }
                        _input = Input;
                        run = false;
                    }
                }
                else
                {
                    Input = new InputModel
                    {
                        ErrorMessage = $"El {Input.Email} ya esta registrado en la base de datos",
                        Email = Input.Email
                    };
                    _input = Input;
                    run = false;
                }
            }
            return run;

        }


        
    }
}
