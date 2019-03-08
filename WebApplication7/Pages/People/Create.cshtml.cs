using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7;
using WebApplication7.Models;

namespace WebApplication7.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public CreateModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            Message = $"{Person.FirstName} {Person.FamilyName} has been added";

            return RedirectToPage("./Index");
        }
    }
}