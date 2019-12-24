using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Servisler;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        public UrunlerController(JsonFileUrunServis UrunServis)
        {
            this.UrunServis = UrunServis;
        }

        public JsonFileUrunServis UrunServis { get; }

        [HttpGet]
        public IEnumerable<Urun> Get()
        {
            return UrunServis.GetProducts();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            UrunServis.AddRating(request.ProductId, request.Rating);
            return Ok();
        }

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}