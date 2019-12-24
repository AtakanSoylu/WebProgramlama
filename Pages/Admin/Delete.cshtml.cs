﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.KullaniciContext _context;

        public DeleteModel(WebApplication3.Data.KullaniciContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kullanici = await _context.Kullanici.FindAsync(id);

            if (Kullanici != null)
            {
                _context.Kullanici.Remove(Kullanici);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
