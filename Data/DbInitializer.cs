using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DbInitializer
    {
        public static void Initialize(KullaniciContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Urun.Any())
            {
                return;   // DB has been seeded
            }

            var urunler = new Urun[]
            {
                new Urun{Id="jenlooper-cactus",Maker="@jenlooper",Image="https://user-images.githubusercontent.com/41929050/61567048-13938600-aa33-11e9-9cfd-712191013192.jpeg",Url="https://www.hackster.io/agent-hawking-1/the-quantified-cactus-an-easy-plant-soil-moisture-sensor-e65393",Title="The Quantified Cactus: An Easy Plant Soil Moisture Sensor",Description="This project is a good learning project to get comfortable with soldering and programming an Arduino."},
                new Urun{Id="jenlooper-light",Maker="jenlooper",Image="https://user-images.githubusercontent.com/41929050/61567049-13938600-aa33-11e9-9c69-a4184bf8e524.jpeg",Url="https://www.hackster.io/agent-hawking-1/book-light-dee7e4",Title="A beautiful switch-on book light",Description="Use craft items you have around the house, plus two LEDs and a LilyPad battery holder, to create a useful book light for reading in the dark."},
                new Urun{Id="jenlooper-survival",Maker="@jenlooper",Image="https://user-images.githubusercontent.com/41929050/61567053-13938600-aa33-11e9-9780-104fe4019659.png",Url="https://www.hackster.io/agent-hawking-1/bling-your-laptop-with-an-internet-connected-light-show-30e4db",Title="Bling your Laptop with an Internet-Connected Light Show",Description="Create a web-connected light-strip API controllable from your website, using the Particle.io."},
                new Urun{Id="sailorhg-bubblesortpic",Maker="sailorhg",Image="https://user-images.githubusercontent.com/41929050/61567054-13938600-aa33-11e9-9163-eec98e239b7a.png",Url="https://twitter.com/sailorhg/status/1090107740049952770",Title="Bubblesort Visualization",Description="Visualization of sailor scouts sorted by bubblesort algorithm by their planet\u0027s distance from the sun" },
            };
            foreach (Urun s in urunler)
            {
                context.Urun.Add(s);
            }
            context.SaveChanges();

            var ulkeler = new Ulke[]
            {
                new Ulke{Id="1",Ulkeismi="Turkiye",Kita="Avrupa",Dil="Turkce",UrunId="jenlooper-light"},
                new Ulke{Id="2",Ulkeismi="Kanada",Kita="Amerika",Dil="Ingilizce",UrunId="jenlooper-survival"},
                new Ulke{Id="3",Ulkeismi="Fransa",Kita="Avrupa",Dil="Fransizca",UrunId="sailorhg-bubblesortpic"},
                new Ulke{Id="4",Ulkeismi="Ingiltre",Kita="Avrupa",Dil="Ingilizce",UrunId="jenlooper-cactus"}
            };
            foreach (Ulke s in ulkeler)
            {
                context.Ulke.Add(s);
            }
            context.SaveChanges();


            var user = new Kullanici[]
            {
                new Kullanici{Id="1",userName="atac1000",Ad="Atakan",Soyad="Soylu",Email="at1000ac@gmail.com",Password="f16426166"}
            };
            foreach (Kullanici s in user)
            {
                context.Kullanici.Add(s);
            }
            context.SaveChanges();



        }
    }
}
