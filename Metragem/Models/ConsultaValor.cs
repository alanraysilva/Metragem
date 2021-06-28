using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metragem.Models
{
    public class ConsultaValor
    {
        [JsonProperty("metragem")]
        public double Metragem { get; set; }
        [JsonProperty("vlimovel")]
        public decimal VlImovel { get; set; }
    }
}