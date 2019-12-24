using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication3.Data.KullaniciContext _context;

        public CreateModel(WebApplication3.Data.KullaniciContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kullanici Kullanici { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kullanici.Add(Kullanici);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
