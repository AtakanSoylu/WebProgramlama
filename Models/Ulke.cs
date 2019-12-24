using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Ulke
    {
        public string Id { get; set; }
        public string Ulkeismi { get; set; }
        public string Kita { get; set; }
        public string Dil { get; set; }
        public string UrunId { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
        public string KullaniciId { get; set; }
        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<Urun> Urun1 { get; set; }
        public virtual ICollection<Kullanici> Kullanici1 { get; set; }
    }



}
