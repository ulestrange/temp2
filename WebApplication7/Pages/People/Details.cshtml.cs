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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public DetailsModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

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
    }
}
