using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.Interfaces;

namespace SMS.WebApp.Host.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Account { get; set; }

        private readonly IAccountServices _services;
        public SignInModel(IAccountServices services)
        {
            _services = services;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result =await _services.LoginAsync(this.Account);
                if (result.Success)
                {
                    return RedirectToPage("/Index");
                }
                
            }

            return Page();
        }
    }
}
