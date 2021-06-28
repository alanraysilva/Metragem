using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metragem.Models
{
    public class Ambiente
    {
        [JsonProperty("lagura")]
        public double Largura { get; set; }
        [JsonProperty("comprimento")]
        public double Comprimento { get; set; }
        [JsonProperty("metragem")]
        public decimal Metragem { get; set; }


        public decimal claculametragem(double largura, double comprimento) 
        {
            return Convert.ToDecimal(comprimento * largura);
        }

    }

}