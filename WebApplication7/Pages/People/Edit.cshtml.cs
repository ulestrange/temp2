using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication7;
using WebApplication7.Models;

namespace WebApplication7.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public EditModel(WebApplication7.Models.WebApplication7Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Message = "Your changes have been saved.";
            return RedirectToPage("./Index");
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.ID == id);
        }
    }
}
