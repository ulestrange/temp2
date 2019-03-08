using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication7;
using WebApplication7.Models;

namespace WebApplication7.Pages.People
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public DeleteModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FindAsync(id);

            if (Person != null)
            {
                _context.Person.Remove(Person);
                await _context.SaveChangesAsync();
            }

            Message = $"{Person.FirstName} {Person.FamilyName} has been deleted";

            return RedirectToPage("./Index");
        }
    }
}
