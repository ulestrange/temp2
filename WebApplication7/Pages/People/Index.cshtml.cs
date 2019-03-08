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
    public class IndexModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public IndexModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        [TempData]

        public string Message { get; set; }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}
