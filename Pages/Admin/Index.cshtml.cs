using System;
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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.KullaniciContext _context;

        public IndexModel(WebApplication3.Data.KullaniciContext context)
        {
            _context = context;
        }

        public IList<Kullanici> Kullanici { get;set; }

        public async Task OnGetAsync()
        {
            Kullanici = await _context.Kullanici.ToListAsync();
        }
    }
}
