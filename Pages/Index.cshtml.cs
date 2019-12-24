using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;
using WebApplication3.Servisler;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileUrunServis UrunServis;
        public IEnumerable<Urun> Urunler { get; private set; }
        public IndexModel(ILogger<IndexModel> logger,JsonFileUrunServis urunServis)
        {

            _logger = logger;
            UrunServis = urunServis;
        }

        public void OnGet()
        {
            Urunler = UrunServis.GetProducts();
        }
    }
}
