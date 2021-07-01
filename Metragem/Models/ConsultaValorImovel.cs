using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metragem.Models
{
    public class ConsultaValorImovel
    {
        [JsonProperty("metroquadrado")]
        public double MetroQuadrado { get; set; }
        [JsonProperty("vlmetro")]
        public decimal VlMetro { get; set; }
    }
}