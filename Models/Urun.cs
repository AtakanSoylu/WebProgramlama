using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Urun
    {
        public string Id { get; set; }
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ulke { get; set; }
        [NotMapped]
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Urun>(this);

    }
}
