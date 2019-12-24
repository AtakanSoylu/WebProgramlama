using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Data.KullaniciContext _context;

        public EditModel(WebApplication3.Data.KullaniciContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kullanici Kullanici { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kullanici = await _context.Kullanici.FirstOrDefaultAsync(m => m.Id == id);

            if (Kullanici == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kullanici).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciExists(Kullanici.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KullaniciExists(string id)
        {
            return _context.Kullanici.Any(e => e.Id == id);
        }
    }
}
