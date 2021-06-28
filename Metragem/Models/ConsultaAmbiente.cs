using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metragem.Models
{
    public class ConsultaAmbiente
    {
        [JsonProperty("lagura")]
        public double Largura { get; set; }
        [JsonProperty("comprimento")]
        public double Comprimento { get; set; }
    }
}